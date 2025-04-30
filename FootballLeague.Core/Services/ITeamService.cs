using FootballLeague.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public interface ITeamService
    {
        public Task<TeamDto> CreateTeamAsync(CreateTeamDto newTeam);

        public Task<TeamDto> GetTeamByIdAsync(int id);

        public Task<IEnumerable<TeamDto>> GetAllTeamsAsync();

        public Task<TeamDto> UpdateTeamAsync(int id, UpdateTeamDto updateTeam);

        public Task<bool> DeleteTeamAsync(int id);
    }
}
