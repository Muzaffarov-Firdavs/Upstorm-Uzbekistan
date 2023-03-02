using Newtonsoft.Json;
using System.Reflection;
using Upstorm.Data.Configurations;
using Upstorm.Data.IRepositories;
using Upstorm.Data.Repositories;
using Upstorm.Domain.Entities;
using Upstorm.Service.DTOs;
using Upstorm.Service.Helpers;
using Upstorm.Service.Interfaces;

namespace Upstorm.Service.Services
{
    public class UserService : IUserService
    {
        private readonly string path = DatabasePath.USER_PATH;
        private readonly IForecastRepository repositoryForecast = new ForecastRepository();
        private readonly IRepository<User> repositoryUser = new Repository<User>();


        //   user  CRUD 
        public async Task<Response<User>> CreateAsync(UserDto userDto)
        {
            var newUser = new User()
            {
                CreatedAt = DateTime.UtcNow,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                Username = userDto.Username,
                Role = Domain.Enums.UserRole.Consumer,
                LookingCity = userDto.LookingCity,
                LookingWeekDay = userDto.LookingWeekDay,
            };

            var entities = await repositoryUser.GetAllAsync();
            var user = entities.FirstOrDefault(x => x.Username == newUser.Username);

            if (user is not null)
            {
                return new Response<User>
                {
                    StatusCode = 405,
                    Message = "Already created",
                    Result = null
                };
            }


            var result = await repositoryUser.CreateAsync(newUser);

            return new Response<User>
            {
                StatusCode = 202,
                Message = "Success",
                Result = result
            };

        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var entities = await repositoryUser.GetAllAsync();
            var user = entities.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return new Response<bool>();
            }

            var result = await repositoryUser.DeleteAsync(id);

            return new Response<bool>
            {
                StatusCode = 202,
                Message = "Success",
                Result = true
            };
        }

        public async Task<Response<List<User>>> GetAllUsersAsync()
        {
            var results =  await repositoryUser.GetAllAsync();

            return new Response<List<User>>
            {
                StatusCode = 202,
                Message = "Success",
                Result = results
            };
        }

        public async Task<Response<User>> GetByIdAsync(long id)
        {
            var model = await repositoryUser.GetByIdAsync(id);

            if (model is null)
            {
                return new Response<User>();
            }

            return new Response<User>
            {
                StatusCode = 202,
                Message = "Success",
                Result = model
            };
        }

        public async Task<Response<User>> UpdateAsync(UserDto userDto)
        {
            var entities = await repositoryUser.GetAllAsync();
            var user = entities.FirstOrDefault(x => x.Username == userDto.Username);

            if (user is null)
            {
                return new Response<User>();
            }

            var newUpdatingModel = new User()
            {
                CreatedAt = DateTime.UtcNow,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                Username = userDto.Username,
                Role = Domain.Enums.UserRole.Consumer,
                LookingCity = userDto.LookingCity,
                LookingWeekDay = userDto.LookingWeekDay,
            };

            var result = await repositoryUser.UpdateAsync(newUpdatingModel);

            return new Response<User>()
            {
                StatusCode = 202,
                Message = "Success",
                Result = result
            };
        }


        // getting  forecast information  services

        public async Task<Response<Dictionary<string, List<Forecast>>>> GetAllAsync()
        {
            var entities = await repositoryForecast.GetAllAsync();

            if (entities is null)
            {
                return new Response<Dictionary<string, List<Forecast>>>();
            }

            return new Response<Dictionary<string, List<Forecast>>>
            {
                StatusCode = 200,
                Message = "Success",
                Result = entities
            };
        }


        public async Task<Response<List<Forecast>>> GetByCityWholeOfWeekAsync(string cityName)
        {
            var entities = await repositoryForecast.GetByCityWholeOfWeekAsync(cityName);

            if (entities is null)
            {
                return new Response<List<Forecast>>();
            }

            return new Response<List<Forecast>>
            {
                StatusCode = 200,
                Message = "Success",
                Result = entities
            };
        }

        public async Task<Response<Forecast>> GetByDayAsync(string cityName, int weekDay)
        {
            var model = await repositoryForecast.GetByDayAsync(cityName, weekDay);

            if (model is null)
            {
                return new Response<Forecast>();
            }

            return new Response<Forecast>
            {
                StatusCode = 200,
                Message = "Success",
                Result = model
            };
        }

    }
}
