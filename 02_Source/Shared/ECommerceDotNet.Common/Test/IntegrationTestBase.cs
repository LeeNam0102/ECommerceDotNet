using Microsoft.Extensions.Configuration;

namespace ECommerceDotNet.Common.Test
{
    public class IntegrationTestBase
    {
        protected static HttpClient _client;
        public static IConfiguration _configuration;
    }
}