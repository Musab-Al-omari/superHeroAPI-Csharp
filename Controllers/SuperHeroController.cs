
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        [Route("super-hero")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpPost]
        [Route("add-hero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }


        [HttpGet]
        [Route("single-hero/{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {

            var foundHero = heroes.Find(hero => hero.Id == id);
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
            var foundHero = heroes.Find(hero => hero.Id == id);
            if (foundHero == null)
            {
                return BadRequest("hero dose not found");

            }
            foundHero.FirstName = body.FirstName;
            foundHero.LastName = body.LastName;
            foundHero.Name = body.Name;
            foundHero.Place = body.Place;
            return Ok(foundHero);
        }



        [HttpDelete]
        [Route("delete-hero/{id}")]
        public async Task<ActionResult<SuperHero>> deleteHero(int id)
        {

            var foundHero = heroes.RemoveAll(hero => hero.Id == id);
            if (foundHero == 0)
            {
                return Ok("no HERO WAS DELETED");
            }
            return Ok(foundHero);
        }

    }
}