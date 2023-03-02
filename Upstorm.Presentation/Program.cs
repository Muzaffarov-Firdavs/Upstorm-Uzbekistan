using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Upstorm.Data.IRepositories;
using Upstorm.Data.Repositories;
using Upstorm.Domain.Entities;
using Upstorm.Domain.Enums;
using Upstorm.Service.DTOs;
using Upstorm.Service.Interfaces;
using Upstorm.Service.Services;

namespace Upstorm.Presentation
{ 
    public class Program
    {
        //   IF YOU TEST MY CODE AND RAISE MY COMMENTS , BEFORE TESTING ONOTHER ONE,
        //    PUT COMMENTS AGAIN BACK . BECAUSE  THERE ARE SIMILAR VARIABLES

        static async Task Main(string[] args)
        {
            IUserService userService = new UserService();

            //    CRUD actions

            /*
            // creating new user
            UserDto user = new UserDto()
            {
                FirstName = "Akmal",
                LastName = "Ali",
                Username = "aju",
                Password = "qwerty",
                LookingCity = "Andijan"
            };

            var result = await userService.CreateAsync(user);
            */

            /*
            //  getting user by id
            var result = await userService.GetByIdAsync(1);
            Console.WriteLine(result.StatusCode + " " + result.Message + " " + result.Result);
            */

            /*
            // getting all 
            var results = await userService.GetAllUsersAsync();
                Console.WriteLine(results.StatusCode + " " + results.Message + " " + results.Result);
            */

            /*
            // updating
            UserDto user = new UserDto()
            {
                FirstName = "Jasur",
                LastName = "Ali",
                Username = "aju",
                Password = "qwerty",
                LookingCity = "Gulistan"
            };

            var result = await userService.UpdateAsync(user);
            */

            /*
            // deleting by id
            var result = await userService.DeleteAsync(1);
            Console.WriteLine(result.StatusCode + " " + result.Message + " " + result.Result);
            */







            // ABOUT WHEATHER WE HAVE INFORMATION FOR 5 CITIES    weekly
            // Andijan ,   Namangan , Fergana , Tashkent , Gulistan

            //     getting   weather forecast information


            /*
            // forecast taking whole informaitions
            var result = await userService.GetAllAsync();

            foreach (var item in result.Result)
            {
                Console.WriteLine(item);
            }
            */

            /*
            //    getting one week iformation in 1 city
            var result = await userService.GetByCityWholeOfWeekAsync("Tashkent");

            string[] days = new string[]
                { "monday", "  tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            int i = 0;

            foreach (var day in result.Result)
            {
                Console.WriteLine($"======={days[i]}========\n" +
                    $"main: {day.Main}\n" +
                    $"main: {day.Humidity}\n" +
                    $"temperature: {day.Temperature}\n" +
                    $"sunrise: {day.Sunrise}\n" +
                    $"sunset: {day.Sunset}\n" +
                    $"wind speed: {day.WindSpeed}\n");
                i++;
            }
            */

            /*
            //  getting information one day  for one city

            // entering number of week days such as : 1 = Monday, 2 = Tuesday, etc.
            int dayNumber = 5;
            string[] days = new string[]
             { "monday", "  tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };


            var result = await userService.GetByDayAsync("Andijan", dayNumber);
            var day = result.Result;

            Console.WriteLine($"======={days[dayNumber -1]}========\n" +
                    $"main: {day.Main}\n" +
                    $"main: {day.Humidity}\n" +
                    $"temperature: {day.Temperature}\n" +
                    $"sunrise: {day.Sunrise}\n" +
                    $"sunset: {day.Sunset}\n" +
                    $"wind speed: {day.WindSpeed}\n");
            */
        }
    }
}