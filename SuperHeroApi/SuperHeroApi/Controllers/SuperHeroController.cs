using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {

            string message = "";
            try
            {
                _context.SuperHeroes.Add(hero);
                await _context.SaveChangesAsync();
                message = "Hero Criado com sucesso!";
                return Ok(
                    new BaseResponse
                    {
                        message = message,
                        response = new { hero },
                        sucesso = true
                    });
            }
            catch (Exception e)
            {
                return Ok(
                    new BaseResponse
                    {
                        message = $"{e}",
                        response = { },
                        sucesso = false
                    });
            }


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> getHero(int id)
        {
            var superhero = await _context.SuperHeroes.FindAsync(id);
            if (superhero == null)
            {
                return BadRequest("SuperHero não encontrado");
            }
            return Ok(superhero);
        }
        [HttpPut]
        public async Task<ActionResult<SuperHero>> changeHero(SuperHero request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
            {
                return BadRequest("Hero Not Found");
            }
            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;
            await _context.SaveChangesAsync();
            return Ok(dbHero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteHero(int id)
        {
            var heroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (heroToDelete == null)
            {
                return BadRequest("Hero não encontrado");
            }
            _context.SuperHeroes.Remove(heroToDelete);
            await _context.SaveChangesAsync();
            return Ok("Hero Removido com sucesso!");
        }
    }
}
