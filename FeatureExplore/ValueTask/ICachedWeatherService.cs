using System.Threading.Tasks;

namespace ValueTaskDemo
{
    public interface ICachedWeatherService
    {
        ValueTask<double> GetWeather();
    }
}
