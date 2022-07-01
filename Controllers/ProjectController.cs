using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnaggleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext context;

        public ProjectController(DataContext context)
        {
            this.context = context;
        }
        /*
        private static List<Project> projs = new List<Project>
        {
            new Project
            {
                Id = 1,
                Name ="Snaggle",
                Description = "First real portfolio project",
                Creator = "Flamestar4"
            },
            new Project
            {
                Id = 2,
                Name ="InsectInspector",
                Description = "First real portfolio project alternate name",
                Creator = "Flamestar4"
            }
        };
        */
        
        
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            return Ok(await this.context.Projects.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Project>> Get(int Id)
        {
            var dbProject = await this.context.Projects.FindAsync(Id);
            if (dbProject == null)
                return BadRequest("nope");
            return Ok(dbProject);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project NewProj)
        {
            this.context.Projects.Add(NewProj);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Projects.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project request)
        {
            var dbProject = this.context.Projects.Find(request.Id);
            if (dbProject == null)
                return BadRequest("Nope");

            dbProject.Name = request.Name;
            dbProject.Description = request.Description;

            await this.context.SaveChangesAsync();
            return Ok(await this.context.Projects.ToListAsync());            
        }
     
    }
}
