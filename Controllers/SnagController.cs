using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnaggleAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class SnagController : ControllerBase
    {

        private static List<Snag> Snags = new List<Snag>
            {
                new Snag
                {
                    Project = "Snaggle",
                    Id = 1,
                    Title = "Should I make project or snag first?",
                    Username = "Firestar4",
                    Description = "I don't know what to do first"
                },
                new Snag
                {
                    Project = "Snaggle",
                    Id = 2,
                    Title = "Am i doing this right",
                    Username = "Firestar4",
                    Description = "Testing out post and put"
                }
            };
        private readonly DataContext context;

        public SnagController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Snag>>> Get()
        {
            return Ok(await this.context.Snags.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Snag>> Get(int Id)
        {
            var snag = await this.context.Snags.FindAsync(Id);
            if (snag == null)
                return BadRequest("Not found");

            return Ok(snag);
        }

        [HttpPost]
        public async Task<ActionResult<List<Snag>>> AddSnag(Snag NewSnag)
        {
            this.context.Snags.Add(NewSnag);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Snags.ToListAsync());
        }

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

