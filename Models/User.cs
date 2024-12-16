using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternshipPlatform.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]

    public class User
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }

        public string? Role { get; set; }

        public string? RefreshToken { get; set; }   

        public DateTime? RefreshTokenExpireTime { get; set; }

        public string? ResetPasswordToken { get; set; } 

        public DateTime? ResetPasswordExpiry { get;set; }


    }
}
