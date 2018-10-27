using System.Threading.Tasks;

namespace ValueTaskDemo
{
    public interface IWeatherService
    {
        Task<double> GetWeather();
    }
}
