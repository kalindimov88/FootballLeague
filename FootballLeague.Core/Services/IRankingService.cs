using FootballLeague.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public interface IRankingService
    {
        Task<RankingDto> AddTeamAync(TeamDto team);

        Task UpdateRankingsAsync(MatchDto match);

        Task<IEnumerable<RankingDto>> GetRankingsAsync();
    }
}
