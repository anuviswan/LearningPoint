using System;
using System.Threading.Tasks;

namespace ValueTaskDemo
{
    public class MockCachedWeatherService : ICachedWeatherService
    {
        private DateTime _lastAccessedTime = DateTime.MinValue;
        private double _lastAccessedValue = 30;
        public async ValueTask<double> GetWeather()
        {
            if(DateTime.Now - _lastAccessedTime < TimeSpan.FromSeconds(10))
            {
                Console.WriteLine($"From {nameof(MockWeatherService)}-Cache");
                return _lastAccessedValue;
            }
            _lastAccessedTime = DateTime.Now;
            Console.WriteLine($"From {nameof(MockWeatherService)}-Server");
            return await Task.FromResult(30);
        }
    }
}
