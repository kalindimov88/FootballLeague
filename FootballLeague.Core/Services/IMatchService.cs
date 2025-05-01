using FootballLeague.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public interface IMatchService
    {
        public Task<MatchDto> CreateMatchAsync(CreateMatchDto newMatch);

        public Task<MatchDto> GetMatchByIdAsync(int id);

        public Task<IEnumerable<MatchDto>> GetAllMatchesAsync();

        public Task<MatchDto> UpdateMatchAsync(int id, UpdateMatchDto updateMatch);

        public Task<bool> DeleteMatchAsync(int id);
    }
}
