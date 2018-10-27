using System;
using System.Threading.Tasks;

namespace ValueTaskDemo
{
    class Program
    {
        private static IWeatherService _weatherService;
        private static ICachedWeatherService _cachedWeatherService;
        static async Task Main(string[] args)
        {
            _weatherService = new MockWeatherService();
            
            for(int i = 0; i < 10; i++)
            {
                await Task.Delay(5000);
                var currentWeather = await _weatherService.GetWeather();
                Console.WriteLine($"Weather @ {DateTime.Now.ToString("hh:mm:ss")}={currentWeather}");
            }



            _cachedWeatherService = new MockCachedWeatherService();

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(5000);
                var currentWeather = await _cachedWeatherService.GetWeather();
                Console.WriteLine($"Weather @ {DateTime.Now.ToString("hh:mm:ss")}={currentWeather}");
            }
            Console.ReadLine();
        }

    }
}
