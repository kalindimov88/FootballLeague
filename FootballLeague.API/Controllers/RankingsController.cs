using FootballLeague.Core.DTOs;
using FootballLeague.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingsController : Controller
    {
        private readonly IRankingService _rankingService;

        public RankingsController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        // GET: api/rankings/
        [HttpGet]
        public async Task<ActionResult<RankingDto>> GetRankings()
        {
            var rankings = await _rankingService.GetRankingsAsync();

            if (rankings == null)
            {
                return NotFound();
            }

            return Ok(rankings);
        }
    }
}
