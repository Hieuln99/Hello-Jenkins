using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherForecast.API.Utility
{
    public static class StringExtensions
    {
        public static T DeserializeObject<T>(string input)
        {
            DefaultContractResolver contractResolver = new ()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            return JsonConvert.DeserializeObject<T>(input, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }
    }
}
