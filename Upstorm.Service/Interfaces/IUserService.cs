using Upstorm.Domain.Entities;
using Upstorm.Service.DTOs;
using Upstorm.Service.Helpers;

namespace Upstorm.Service.Interfaces
{
    public interface IUserService
    {
        // User crud 

        Task<Response<User>> CreateAsync(UserDto userDto);
        Task<Response<User>> UpdateAsync(UserDto userDto);
        Task<Response<User>> GetByIdAsync(long id);
        Task<Response<bool>> DeleteAsync(long id);
        Task<Response<List<User>>> GetAllUsersAsync();


        // taking information about forecast
        Task<Response<Forecast>> GetByDayAsync(string cityName, int weekDay);
        Task<Response<List<Forecast>>> GetByCityWholeOfWeekAsync(string cityName);
        Task<Response<Dictionary<string,List<Forecast>>>> GetAllAsync();
    }
}
