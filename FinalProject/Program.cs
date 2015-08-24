using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// A simple program to try WeatherLib
    /// </summary>
    class Program 
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                IWeatherDataService n = new WeatherDataServiceFactory().GetWeatherDataService(1);

                WeatherData wd = n.GetWeatherData(new Location("Haifa", "il")); //getting weather data by location - Haifa, IL
                if(wd != null) Console.WriteLine(wd + "\n");

                wd = n.GetWeatherData(524901); //getting weather data by city id - Moscow, RU
                if (wd != null) Console.WriteLine(wd + "\n");

                wd = n.GetWeatherData(new GeoCoordinations(35, 139)); //getting weather data by geographic coordinations - Shuzenji, JP
                if (wd != null) Console.WriteLine(wd + "\n");
            }
            catch(WeatherDataServiceException e)
            {
                Console.WriteLine("Excption cought:\n" + e.ToString());
            }
        }
    }
}
