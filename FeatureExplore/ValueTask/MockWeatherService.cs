using System;
using System.Threading.Tasks;

namespace ValueTaskDemo
{
    public class MockWeatherService : IWeatherService
    {
        public async Task<double> GetWeather()
        {
            Console.WriteLine($"From {nameof(MockWeatherService)}");
            return await Task.FromResult(30);
        }
    }
}
