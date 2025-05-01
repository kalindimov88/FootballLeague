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
    public class MatchService : IMatchService
    {
        private readonly IRepository _repository;

        public MatchService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchDto> CreateMatchAsync(CreateMatchDto newMatch)
        {
            var match = new Match
            {
                HomeTeamId = newMatch.HomeTeamId,
                AwayTeamId = newMatch.AwayTeamId,
                HomeTeamScore = newMatch.HomeTeamScore,
                AwayTeamScore = newMatch.AwayTeamScore,
                MatchDate = DateTime.UtcNow
            };

            await _repository.AddAsync<Match>(match);

            return MapToDto(match);
        }
        public async Task<bool> DeleteMatchAsync(int id)
        {
            var match = await _repository.GetByIdAsync<Match>(id);

            if (match == null)
            {
                return false;
            }

            await _repository.DeleteAsync<Match>(match);
            return true;
        }

        public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
        {
            var matches = await _repository.SetNoTracking<Match>().ToListAsync();

            return matches.Select(match => MapToDto(match));
        }

        public async Task<MatchDto> GetMatchByIdAsync(int id)
        {
            var match = await _repository.GetByIdAsync<Match>(id);

            if (match == null)
            {
                return null;
            }

            return MapToDto(match);
        }

        public async Task<MatchDto> UpdateMatchAsync(int id, UpdateMatchDto updateMatch)
        {
            var match = await _repository.GetByIdAsync<Match>(id);

            if (match == null)
            {
                return null;
            }

            match.HomeTeamId = updateMatch.HomeTeamId;
            match.AwayTeamId = updateMatch.AwayTeamId;
            match.HomeTeamScore = updateMatch.HomeTeamScore;
            match.AwayTeamScore = updateMatch.AwayTeamScore;
            await _repository.UpdateAsync<Match>(match);

            return MapToDto(match);
        }

        private MatchDto MapToDto(Match match)
        {
            return new MatchDto
            {
                Id = match.Id,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                HomeTeamScore = match.HomeTeamScore,
                AwayTeamScore = match.AwayTeamScore,
                MatchDate = match.MatchDate
            };
        }
    }
}
