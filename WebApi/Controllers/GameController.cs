using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        static private List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Title = "Spider-Man",
                Platform = "PS5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interactive"
            },
            new Game
            {
                Id = 2,
                Title = "The Legen of Zelda",
                Platform = "Nintenao Switch",
                Developer = "Nintenao Games",
                Publisher = "Nintenao"
            },
            new Game
            {
                Id = 3,
                Title = "Cyberpunk",
                Platform = "PS5",
                Developer = "CD Project Games",
                Publisher = "CD Project"
            },
        };
        [HttpGet]
        public ActionResult<List<Game>> GetGame()
        {
            return Ok(games);
        }
        [HttpGet("{id}")]
        //[HttpGet - we can write separately as well
        //[Route("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public ActionResult<Game> AddGame(Game newGame)
        {
            if (newGame is null)
                return BadRequest();
            newGame.Id = games.Max(g => g.Id) + 1;
            games.Add(newGame);
            return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id}, newGame);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, Game updateGame)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound();
            game.Title = updateGame.Title;
            game.Platform = updateGame.Platform;
            game.Developer = updateGame.Developer;
            game.Publisher = updateGame.Publisher;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound();
            games.Remove(game);
            return NoContent();
        }

    }
}
