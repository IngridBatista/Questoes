using Refit;

namespace Questao2
{
    internal interface ApiClient
    {
        [Get("/football_matches")]
        Task <FootballMatches> GetFootballMatches(string team1, string team2, int year);
    }
}
