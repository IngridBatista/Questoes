
using Newtonsoft.Json;

namespace Questao2
{
    public class FootballMatches
    {
        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("per_page")]
        public int per_page { get; set; }

        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("total_pages")]
        public int total_pages { get; set; }

        [JsonProperty("data")]
        public List<Data> data { get; set; }
    }

    public class Data
    {
        [JsonProperty("competition")]
        public string competition { get; set; }

        [JsonProperty("year")]
        public int year { get; set; }

        [JsonProperty("round")]
        public string round { get; set; }

        [JsonProperty("team1")]
        public string team1 { get; set; }

        [JsonProperty("team2")]
        public string team2 { get; set; }

        [JsonProperty("team1goals")]
        public string team1goals { get; set; }

        [JsonProperty("team2goals")]
        public string team2goals { get; set; }
    }
}
