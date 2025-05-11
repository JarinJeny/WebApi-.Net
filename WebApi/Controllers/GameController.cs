using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(GameDBContext context) : ControllerBase
    {
        private readonly GameDBContext _context= context;


        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGame()
        {
            return Ok(await _context.Games.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game newGame)
        {
            if (newGame is null)
                return BadRequest();
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, Game updateGame)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            game.Title = updateGame.Title;
            game.Platform = updateGame.Platform;
            game.Developer = updateGame.Developer;
            game.Publisher = updateGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
