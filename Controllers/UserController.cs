using InternshipPlatform.Data;
using InternshipPlatform.Helpers;
using InternshipPlatform.Models.DTO;
using InternshipPlatform.Services.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _authcontext;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public UserController(DataContext dataContext , IConfiguration config, IEmailService emailService)
        {
            _authcontext = dataContext;
            _config = config;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User userobj)
        {
            if (userobj == null)
            {
                return BadRequest();
            }
            var user = await _authcontext.Users.FirstOrDefaultAsync(x => x.Email == userobj.Email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found!" });
            }
            if (!PasswordHasher.VerifyPassword(userobj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is incorrect!" });
            }

            user.Token = CreateJwt(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _authcontext.SaveChangesAsync();


            return Ok(new TokenAPIDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken


            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        {
            if (userobj == null)
            {
                return BadRequest();
            }


            if (await CheckUserNameExistAsync(userobj.Username))
            {
                return BadRequest(new { Message = "Username Already Exists!" });

            }
            if (await CheckEmailExistAsync(userobj.Email))
            {
                return BadRequest(new { Message = "Email Already Exists!" });

            }

            var pass = CheckPasswordStrength(userobj.Password);
            if (!string.IsNullOrEmpty(pass)) {
                return BadRequest(new { Message = pass.ToString() });

            }

            userobj.Password = PasswordHasher.HashPassword(userobj.Password);
            userobj.Role = "User";
            userobj.Token = "";
            await _authcontext.Users.AddAsync(userobj);
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });

        }

        private async Task<bool> CheckUserNameExistAsync(string username)
        {
            return await _authcontext.Users.AnyAsync(x => x.Username == username);
        }
        private async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _authcontext.Users.AnyAsync(x => x.Email == email);
        }
        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 12)
            {
                sb.Append("Minimum Password Length should be 12" + Environment.NewLine);
            }
            if ((Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))
            {
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            }
            if (!Regex.IsMatch(password, "[., +, *, ?, ^, $, (, ), [, , {, }, \\,!,?,=,_,.,',&,@,#,<,>]"))
            {
                sb.Append("Password should contain at least one special character" + Environment.NewLine);
            }

            return sb.ToString();
        }

        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secretkeysecretkey......");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Name ,$"{user.Username}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(15),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);

        }

        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _authcontext.Users.Any(a => a.RefreshToken == refreshToken);
            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("secretkeysecretkey......");
            var tokenValidationParameters = new TokenValidationParameters

            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null | !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("This is an invalid token");
            }
            return principal;

        }
        [HttpGet("GetAllUsers")]

        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authcontext.Users.ToListAsync());
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenAPIDto tokenApiDto)
        {
            if (tokenApiDto is null) {
                return BadRequest("Invalid Client Request");
            }
            string accessToken = tokenApiDto.AccessToken;
            string refreshToken = tokenApiDto.RefreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = await _authcontext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpireTime <= DateTime.Now)
            {
                return BadRequest("Invalid Request");
            }
            var newAccessToken = CreateJwt(user);
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _authcontext.SaveChangesAsync();
            return Ok(new TokenAPIDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });

        }
        [HttpPost("send-reset-password/{email}")]

        public async Task<IActionResult> SendEmail(string email)
        {
            var user = await _authcontext.Users.FirstOrDefaultAsync(a=> a.Email == email);  
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Email Doesn't Exist"
                });
            }
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var emailToken = Convert.ToBase64String(tokenBytes);
            user.ResetPasswordToken = emailToken;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(15);
            string from = _config["EmailSettings:From"];
            var emailModel = new Email(email,"Reset Password",EmailBody.EmailStringBody(email,emailToken));
            _emailService.SendEmail(emailModel);
            _authcontext.Entry(user).State = EntityState.Modified;
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Email Sent!"
            });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto) 
        {
            var newToken = resetPasswordDto.EmailToken.Replace("", "+");
            var user = await _authcontext.Users.AsNoTracking().FirstOrDefaultAsync(a => a.Email == resetPasswordDto.Email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Doesn't Exist"
                });
            }
            var tokenCode = user.ResetPasswordToken;
            DateTime? emailTokenExpiry = user.ResetPasswordExpiry;
            if(tokenCode != resetPasswordDto.EmailToken || emailTokenExpiry < DateTime.Now)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Invalid Reset Link"
                });
            }
            user.Password = PasswordHasher.HashPassword(resetPasswordDto.NewPassword);
            _authcontext.Entry(user).State = EntityState.Modified;
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Password Reset Successfully"
            });



        }

    }

}
