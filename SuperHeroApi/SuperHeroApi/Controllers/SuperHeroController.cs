using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero> {
                new SuperHero {
                    Id = 1,
                    Name =  "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes.Find(x => x.Id == hero.Id));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> getHero(int id)
        {
            return Ok(heroes.Find(x => x.Id == id));
        }
        [HttpPut]
        public async Task<ActionResult<SuperHero>> changeHero(SuperHero request)
        {
            var hero = heroes.Find(x => x.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(hero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteHero(int id)
        {
            var heroToDelete = heroes.Find(x => x.Id == id);
            if (heroToDelete == null)
            {
                return BadRequest("Hero não encontrado");
            }
            heroes.Remove(heroToDelete);
            return Ok("Hero Removido com sucesso!");
        }
    }
}
