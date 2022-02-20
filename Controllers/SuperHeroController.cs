
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace superHeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>{
                new SuperHero{Id=1,Name="MAN",FirstName="PETER",LastName="PARKER",Place="NEWYORK"},
                new SuperHero{Id=2,Name="XX",FirstName="XX",LastName="XXXXC",Place="XXXX"},
                new SuperHero{Id=3,Name="CC",FirstName="CCC",LastName="CCCCC",Place="CCCC"},
            };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            this._context = context;
        }


        [HttpGet]
        [Route("super-hero")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHero.ToListAsync());
        }


        [HttpPost]
        [Route("add-hero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHero.Add(hero);
            var isAdded = await _context.SaveChangesAsync();
            return Ok(isAdded);
        }


        [HttpGet]
        [Route("single-hero/{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {

            var foundHero = await _context.SuperHero.FindAsync(id);
            if (foundHero == null)
            {
                return BadRequest("hero dose not found");

            }
            return Ok(foundHero);
        }

        [HttpPut]
        [Route("edit-hero/{id}")]
        public async Task<ActionResult<SuperHero>> EditSingleHero(int id, [FromBody] SuperHero body)
        {
            var foundHero = await _context.SuperHero.FindAsync(id);
            if (foundHero == null)
            {
                return BadRequest("hero dose not found");
            }

            foundHero.FirstName = body.FirstName;
            foundHero.LastName = body.LastName;
            foundHero.Name = body.Name;
            foundHero.Place = body.Place;
            await _context.SaveChangesAsync();
            return Ok(foundHero);
        }



        [HttpDelete]
        [Route("delete-hero/{id}")]
        public async Task<ActionResult> deleteHero(int id)
        {
            var foundHero = await _context.SuperHero.FindAsync(id);
            if (foundHero == null)
            {
                return Ok("no HERO WAS DELETED");
            }
            _context.SuperHero.Remove(foundHero);
            await _context.SaveChangesAsync();
            return Ok(foundHero);
        }

    }
}