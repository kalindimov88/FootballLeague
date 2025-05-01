using FootballLeague.Core.DTOs;
using FootballLeague.Data.Models;
using FootballLeague.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository _repository;
        private readonly IRankingService _rankingService;

        public TeamService(IRepository repository, IRankingService rankingService)
        {
            _repository = repository;
            _rankingService = rankingService;
        }

        public async Task<TeamDto> CreateTeamAsync(CreateTeamDto newTeam)
        {
            var team = new Team
            {
                Name = newTeam.Name,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync<Team>(team);
            var teamDto = MapToDto(team);
            await _rankingService.AddTeamAync(teamDto);

            return teamDto;
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _repository.GetByIdAsync<Team>(id);

            if (team == null)
            {
                return null;
            }

            return MapToDto(team);
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _repository.SetNoTracking<Team>().ToListAsync();

            return teams.Select(team => MapToDto(team));
        }

        public async Task<TeamDto> UpdateTeamAsync(int id, UpdateTeamDto updateTeam)
        {
            var team = await _repository.GetByIdAsync<Team>(id);

            if (team == null)
            {
                return null;
            }

            team.Name = updateTeam.Name;
            await _repository.UpdateAsync<Team>(team);

            return MapToDto(team);
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _repository.GetByIdAsync<Team>(id);

            if (team == null)
            {
                return false;
            }

            await _repository.DeleteAsync<Team>(team);
            return true;
        }

        private TeamDto MapToDto(Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                CreatedDate = team.CreatedDate
            };
        }
    }
}
