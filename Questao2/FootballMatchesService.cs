using System.Text.Json;

namespace Questao2
{
    internal class FootballMatchesService
    {
        private static HttpClient client = new HttpClient();
        private string baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

        public FootballMatchesService() { }

        public int GoalCalculation(string team, int year)
        {
            var goalsValuesTeam1 = SumOfScores(team, year, "team1");
            var goalsValuesTeam2 = SumOfScores(team, year, "team2");
            return goalsValuesTeam1 + goalsValuesTeam2;

        }

        public int SumOfScores(string team, int year, string teamId)
        {
            var sumOfScore = 0;
            var result = GetFootballMatches(teamId, team, year, 1);

            foreach (var item in result.data)
            {
                sumOfScore += CountGoalsForTeam(teamId, item); ;
            }

            if (result.total_pages > 1)
            {
                for (var _page = 2; _page <= result.total_pages; _page++)
                {
                    var _result = GetFootballMatches(teamId, team, year, _page);

                    foreach (var item in _result.data)
                    {
                        sumOfScore += CountGoalsForTeam(teamId, item);
                    }
                }
            }

            return sumOfScore;
        }

        public int CountGoalsForTeam(string teamId, Data item)
        {
            switch (teamId)
            {
                case "team1": return Int32.Parse(item.team1goals);
                case "team2": return Int32.Parse(item.team2goals);
            }

            throw new Exception("invalid teamId");
        }
        private FootballMatches GetFootballMatches(string teamId, string team, int year, int page)
        {
            var url = $"{baseUrl}?page={page}&year={year}&{teamId}={team}";
            return ExecuteRequest(url);
        }

        public FootballMatches ExecuteRequest(string request)
        {
            HttpResponseMessage response = client.GetAsync(request).Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result.ToString();
            return JsonSerializer.Deserialize<FootballMatches>(content);
        }
    }
}
