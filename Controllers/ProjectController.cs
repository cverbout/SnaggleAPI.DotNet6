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

        [HttpGet]
        public async Task<ActionResult<Project>> Get()
        {
            return Ok(await context.Projects.Include("Snags").ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Project>> Get(int Id)
        {
            var dbProject = await this.context.Projects
                .Where(p => p.Id == Id)
                .Include(p => p.Snags)
                .ToListAsync();

            if (dbProject == null)
                return BadRequest("nope");
            return Ok(dbProject);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(CreateProjectDto request)
        {
            var NewProj = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            this.context.Projects.Add(NewProj);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Projects.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Project>>> UpdateProject(UpdateProjectDto request)
        {
            var dbProject = this.context.Projects.Find(request.Id);
            if (dbProject == null)
                return BadRequest("Nope");

            dbProject.Name = request.Name;
            dbProject.Description = request.Description;
            dbProject.Updated = DateTime.Now;

            await this.context.SaveChangesAsync();
            return Ok(await this.context.Projects.ToListAsync());

        }
        
        // Delete Methods

        [HttpDelete]
        public async Task<ActionResult<Project>> Delete(int Id)
        {
            var DbSnag = await context.Projects.FindAsync(Id);
            if (DbSnag == null)
                return NotFound("Nope");

            context.Projects.Remove(DbSnag);
            await context.SaveChangesAsync();

            return await Get();

        }
    }

}
