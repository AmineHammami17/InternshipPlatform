using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipsController : ControllerBase
    {
        private static List<Internships> InternshipList = new List<Internships>
            {
                new Internships{ Id = 1 ,
                    Title= "",
                    Description="",
                    Duration="" ,
                    Status="",
                    Category="",
                    NumberInterns=0,
                    Type=""},
                new Internships{ Id = 2 ,
                    Title= "",
                    Description="",
                    Duration="" ,
                    Status="",
                    Category="",
                    NumberInterns=2,
                    Type=""}

            };


        [HttpGet] 
        public async Task <ActionResult<List<Internships>>> GetAllInternships()
        {
           
            return Ok(InternshipList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Internships>> GetInternship(int id)
        {
            var internship = InternshipList.Find(x => x.Id == id);
            if (internship is not null)
                return Ok(internship);
            return NotFound("The internship does not exist");
        }

        [HttpPost]
        public async Task<ActionResult<List<Internships>>> AddInternship(Internships internship)
        {
            InternshipList.Add(internship);
            return Ok(InternshipList);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Internships>>> UpdateInternship(int id ,Internships request)
        {
            var internship = InternshipList.Find(x => x.Id == id);
            if (internship is not null)
                internship.Title = request.Title;
                internship.Description = request.Description;
                internship.Duration = request.Duration;
                internship.Status = request.Status;
                internship.Category = request.Category;
                internship.NumberInterns = request.NumberInterns;
                internship.Type = request.Type;
                return Ok(InternshipList);


            return NotFound("The internship does not exist");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Internships>>> DeleteHero(int id, Internships request)
        {
            var internship = InternshipList.Find(x => x.Id == id);
            if (internship is not null)
                InternshipList.Remove(internship);
                return Ok(InternshipList);


            return NotFound("The internship does not exist");
        }




    }
}
