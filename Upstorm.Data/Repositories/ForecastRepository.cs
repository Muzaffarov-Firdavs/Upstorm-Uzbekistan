using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Upstorm.Data.Configurations;
using Upstorm.Data.IRepositories;
using Upstorm.Domain.Entities;

namespace Upstorm.Data.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly string path = DatabasePath.WEATHER_INFORMATION_PATH;

        public async Task<Dictionary<string, List<Forecast>>> GetAllAsync()
        {
            string text = File.ReadAllText(path);

            if (string.IsNullOrEmpty(text))
            {
                text = "[]";
            }

            var results = JsonConvert.DeserializeObject<Dictionary<string, List<Forecast>>>(text);

            return results;
        }

        public async Task<List<Forecast>> GetByCityWholeOfWeekAsync(string cityName)
        {
            var entities = await GetAllAsync();

            return entities.FirstOrDefault(x => x.Key == cityName).Value;
        }

        public async Task<Forecast> GetByDayAsync(string cityName, int weekDay)
        {
            var entities = await GetByCityWholeOfWeekAsync(cityName);

            var result = entities[weekDay - 1];

            return result;
        }
    }
}
