namespace FootballLeague.Core.DTOs
{
    public class CreateMatchDto
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }
    }
}
