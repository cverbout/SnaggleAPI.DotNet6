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
            return Ok(await this.context.Snags.ToListAsync());
        }

        [HttpGet("{Id}/Id")]
        public async Task<ActionResult<Snag>> Get(int Id)
        {
            var snag = await this.context.Snags.FindAsync(Id);
            if (snag == null)
                return BadRequest("Not found");

            return Ok(snag);
        }

     
        [HttpGet("{CurrentStatus}/CS")]
        public async Task<ActionResult<Snag>> Get(Status CurrentStatus)
        {
            var snags = await this.context.Snags.Where(snag => snag.CurrentStatus == CurrentStatus).ToListAsync();

            if (!snags.Any())
                return NotFound();

            return Ok(snags);
        }

        // Post Methods

        [HttpPost]
        public async Task<ActionResult<List<Snag>>> AddSnag(Snag NewSnag)
        {
            this.context.Snags.Add(NewSnag);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Snags.ToListAsync());
        }

        // Put Methods

        [HttpPut]
        public async Task<ActionResult<List<Snag>>> UpdateSnag(Snag request)
        {
            var DbSnag = await this.context.Snags.FindAsync(request.Id);
            if (DbSnag == null)
                return BadRequest("Not found");
            DbSnag.Title = request.Title;
            DbSnag.Description = request.Description;
            DbSnag.CurrentStatus = request.CurrentStatus;
            DbSnag.UpdatedDate = DateTime.Now;

            await this.context.SaveChangesAsync();

            return Ok(await this.context.Snags.ToListAsync());
        }

        // Delete Methods

        [HttpDelete]
        public async Task<ActionResult<List<Snag>>> DeleteSnag(int Id)
        {
            var DbSnag = await this.context.Snags.FindAsync(Id);
            if (DbSnag == null)
                return BadRequest("Not found sorry");

            this.context.Snags.Remove(DbSnag);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.Snags.ToListAsync());
        }


    }
}

