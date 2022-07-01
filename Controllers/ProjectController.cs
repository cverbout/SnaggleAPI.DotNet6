using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnaggleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private static List<Project> projs = new List<Project>
        {
            new Project
            {
                Id = 1,
                Name ="Snaggle",
                Description = "First real portfolio project",
                Creator = "Flamestar4",
                SnagList = {9, 10}
            },
            new Project
            {
                Id = 2,
                Name ="InsectInspector",
                Description = "First real portfolio project alternate name",
                Creator = "Flamestar4",
                SnagList = {11}
            }
        };
 
        
        
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(projs);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Project>> Get(int Id)
        {
            var found = projs.Find(p => p.Id == Id);
            if (found == null)
                return BadRequest("nope");
            return Ok(found);
        }

     
    }
}
