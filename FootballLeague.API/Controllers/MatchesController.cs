using FootballLeague.Core.DTOs;
using FootballLeague.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: api/matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetAll()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(matches);
        }

        // GET: api/matches/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetById(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // POST: api/matches
        [HttpPost]
        public async Task<ActionResult<MatchDto>> Create([FromBody] CreateMatchDto newMatch)
        {
            var createdMatch = await _matchService.CreateMatchAsync(newMatch);
            return CreatedAtAction(nameof(GetById), new { id = createdMatch.Id }, createdMatch);
        }

        // PUT: api/matches/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMatchDto updateMatch)
        {
            var match = await _matchService.UpdateMatchAsync(id, updateMatch);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // DELETE: api/matches/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _matchService.DeleteMatchAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
