using Microsoft.Extensions.Configuration;

namespace Infrastructure.Core
{
    public class DataProvider
    {
        public string SolutionDbContext { get; set; }

        public DataProvider(IConfiguration configuration)
        {
            SolutionDbContext = configuration.GetSection("Database:Solution").Value;
        }
    }
}