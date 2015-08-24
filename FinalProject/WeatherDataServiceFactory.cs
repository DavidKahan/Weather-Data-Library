using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// This class implemnts factory design pattern and provide weather data service according to parameter id.
    /// </summary>
    public class WeatherDataServiceFactory
    {
        const int OPEN_WEATHER_MAP = 1;
        
        /// <summary>
        /// Returns weather data service object according to specified type.
        /// </summary>
        public  IWeatherDataService GetWeatherDataService(int type)
        {
            if (type == OPEN_WEATHER_MAP)
            {
                return OpenWeatherMap.GetInstance();
            }
            else
            {
                throw new WeatherDataServiceException("No such service code");
            }
        }
    }
}
