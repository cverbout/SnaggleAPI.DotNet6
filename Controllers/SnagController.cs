using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnaggleAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class SnagController : ControllerBase
    {

        private readonly DataContext context;

        public SnagController(DataContext context)
        {
            this.context = context;
        }

        // Get Methods

        [HttpGet]
        public async Task<ActionResult<List<Snag>>> Get()
        {
            return Ok(await context.Snags.ToListAsync());
        }

        [HttpGet("{Id}/Id")]
        public async Task<ActionResult<Snag>> Get(int Id)
        {
            var snag = await context.Snags.FindAsync(Id);
            if (snag == null)
                return BadRequest("Not found");

            return Ok(snag);
        }

        [HttpGet("{ProjectId}/ProjectId")]
        public async Task<ActionResult<Snag>> GetProjectSnags(int ProjectId)
        {
            var snags = await context.Snags
                .Where(s => s.ProjectId == ProjectId)
                .ToListAsync();

            if (!snags.Any())
                return NotFound("Nope");

            return Ok(snags);
        }

        [HttpGet("{CurrentStatus}/CS")]
        public async Task<ActionResult<Snag>> GetProjectStatusSnags(int ProjectId, Status CurrentStatus)
        {
            var snags = await context.Snags
                .Where(s => s.ProjectId == ProjectId)
                .Where(s => s.CurrentStatus == CurrentStatus)
                .ToListAsync();

            if (!snags.Any())
                return NotFound("Nope");

            return Ok(snags);
        }

        // Post Methods

        [HttpPost]
        public async Task<ActionResult<Snag>> CreateSnag(CreateSnagDto request)
        {
            var Proj = await context.Projects.FindAsync(request.ProjectId);
            if (Proj == null)
                return NotFound();

            var NewSnag = new Snag
            {
                Title = request.Title,
                Username = request.Username,
                Description = request.Description,
                Project = Proj

            };
            context.Snags.Add(NewSnag);
            await context.SaveChangesAsync();

            return await Get(NewSnag.Id);
        }

        // Put Methods

        [HttpPut]
        public async Task<ActionResult<List<Snag>>> UpdateSnag(UpdateSnagDto request)
        {
            var DbSnag = await context.Snags.FindAsync(request.Id);
            if (DbSnag == null)
                return BadRequest("Not found");
            DbSnag.Title = request.Title;
            DbSnag.Description = request.Description;
            DbSnag.CurrentStatus = request.CurrentStatus;
            DbSnag.UpdatedDate = DateTime.Now;
            

            await context.SaveChangesAsync();

            return Ok(await context.Snags.ToListAsync());
        }

        // Delete Methods

        [HttpDelete]
        public async Task<ActionResult<Snag>> DeleteSnag(int Id)
        {
            var DbSnag = await context.Snags.FindAsync(Id);
            if (DbSnag == null)
                return BadRequest("Not found sorry");

            var ProjId = DbSnag.ProjectId;

            context.Snags.Remove(DbSnag);
            await context.SaveChangesAsync();

            return await GetProjectSnags(ProjId);
        }


    }
}

