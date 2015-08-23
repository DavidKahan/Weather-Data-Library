using System;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provide the basic mathod declarations for weather data services classes that implements it.
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        /// Get WeatherData object by location
        /// </summary>
        WeatherData GetWeatherData(Location location);

        /// <summary>
        /// Get WeatherData object by geographic coordinations
        /// </summary>
        WeatherData GetWeatherData(GeoCoordinations geoCord);

        /// <summary>
        /// Get WeatherData object by city ID
        /// </summary>
        WeatherData GetWeatherData(int cityID);
    }
}
