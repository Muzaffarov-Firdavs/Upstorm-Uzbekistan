using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upstorm.Domain.Entities;

namespace Upstorm.Data.IRepositories
{
    public interface IForecastRepository
    {
        Task<Forecast> GetByDayAsync(string cityName, int weekDay);
        Task<List<Forecast>> GetByCityWholeOfWeekAsync(string cityName);
        Task<Dictionary<string, List<Forecast>>> GetAllAsync();
    }
}
