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
    public class RankingService : IRankingService
    {
        private readonly IRepository _repository;

        public RankingService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<RankingDto> AddTeamAync(TeamDto team)
        {
            var ranking = new Ranking
            {
                TeamId = team.Id,
                UpdatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync<Ranking>(ranking);

            return MapToDto(ranking);
        }

        public async Task<IEnumerable<RankingDto>> GetRankingsAsync()
        {
            var rankings = await _repository.SetNoTracking<Ranking>("Team").ToListAsync();

            return rankings.Select(ranking => MapToDto(ranking)).OrderBy(record => record.Rank);
        }

        public async Task UpdateRankingsAsync(MatchDto match)
        {
            var rankings = await _repository.Set<Ranking>().ToListAsync();

            var homeTeam = rankings.FirstOrDefault(r => r.TeamId == match.HomeTeamId);
            var awayTeam = rankings.FirstOrDefault(r => r.TeamId == match.AwayTeamId);

            if (homeTeam == null || awayTeam == null)
                return;

            homeTeam.GoalsFor += match.HomeTeamScore;
            homeTeam.GoalsAgainst += match.AwayTeamScore;
            homeTeam.GoalDifference = homeTeam.GoalsFor - homeTeam.GoalsAgainst;

            awayTeam.GoalsFor += match.AwayTeamScore;
            awayTeam.GoalsAgainst += match.HomeTeamScore;
            awayTeam.GoalDifference = awayTeam.GoalsFor - awayTeam.GoalsAgainst;

            if (match.HomeTeamScore > match.AwayTeamScore)
            {
                homeTeam.Points += 3;
            }
            else if (match.HomeTeamScore < match.AwayTeamScore)
            {
                awayTeam.Points += 3;
            }
            else
            {
                homeTeam.Points += 1;
                awayTeam.Points += 1;
            }

            var ordered = rankings
                .OrderByDescending(r => r.Points)
                .ThenByDescending(r => r.GoalDifference)
                .ThenByDescending(r => r.GoalsFor)
                .ToList();

            for (int i = 0; i < ordered.Count; i++)
            {
                ordered[i].Rank = i + 1;
            }

            await _repository.SaveChangesAsync();
        }

        private RankingDto MapToDto(Ranking ranking)
        {
            if (ranking == null)
            {
                return null;
            }

            return new RankingDto
            {
                Id = ranking.Id,
                Rank = ranking.Rank,
                TeamId = ranking.TeamId,
                GoalsFor = ranking.GoalsFor,
                GoalsAgainst = ranking.GoalsAgainst,
                GoalDifference = ranking.GoalDifference,
                Points = ranking.Points,
                Team = MapToDto(ranking.Team),
                UpdatedDate = ranking.UpdatedDate
            };
        }

        private TeamDto MapToDto(Team team)
        {
            if (team == null)
            { 
                return null;
            }

            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                CreatedDate = team.CreatedDate
            };
        }
    }
}
