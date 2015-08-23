using System;
using System.Xml.Linq;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.FinalProject.WeatherLib 
{
    /// <summary>
    /// This class implemnts IWeatherDataService and eventually return the Weather data from openweathermap API.
    /// It implements singleton design pattern.
    /// </summary>
    public class OpenWeatherMap : IWeatherDataService 
    {    
        private static OpenWeatherMap instance = null;
        private OpenWeatherMap(){}

        /// <summary>
        /// Singleton implementation - returns single instance for this class.
        /// </summary>
        public static OpenWeatherMap GetInstance() 
        {
            if(instance == null) 
            {
                instance = new OpenWeatherMap();
            }
            return instance;
        }

        /// <summary>
        /// Returns WeatherData object by location
        /// </summary>
        public WeatherData GetWeatherData(Location location) 
        {
            string city = location.City;
            string country = location.Country;
            string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + city + "," + country + "&mode=xml";
            WeatherData wd = null;
            try
            {
                wd = ParseWeatherDataXml(url);
            }
            catch(WeatherDataServiceException e)
            {
                Console.WriteLine(e.ToString());
            }
            return wd;
        }

        /// <summary>
        /// Get WeatherData object by geographic coordinations
        /// </summary>
        public WeatherData GetWeatherData(GeoCoordinations geoCoord)
        {
            double lat = geoCoord.Latitude;
            double lon = geoCoord.Longtitude;
            string url = "http://api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" + lon + "&mode=xml";
            WeatherData wd = null;
            try
            {
                wd = ParseWeatherDataXml(url);
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.ToString());
            }
            return wd;
        }

        /// <summary>
        /// Get WeatherData object by city ID
        /// </summary>
        public WeatherData GetWeatherData(int cityID)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?id="+ cityID +"&mode=xml";
            WeatherData wd = null;
            try
            {
                wd = ParseWeatherDataXml(url);
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.ToString());
            }
            return wd;
        }

         /// <summary>
        /// Parsing of weather data service XML - returns WeatherData object with all weather details
        /// </summary>
        private WeatherData ParseWeatherDataXml(string url)
        {
            XDocument xdoc = null;
            WeatherData wd = null;

            try
            {
                //getting xml document from url
                string xml = new WebClient().DownloadString(url);
                xdoc = XDocument.Parse(xml);

                var locNode = xdoc.Element("weatherdata").Element("location");
                var timeNode = xdoc.Element("weatherdata").Element("forecast").Element("time");

                //getting location values from xml
                Location location = new Location(locNode.Element("name").Value, locNode.Element("country").Value);

                //getting time values from xml
                Time time = new Time(timeNode.Attribute("from").Value, timeNode.Attribute("to").Value);

                //getting clouds description from xml
                string clouds = timeNode.Element("clouds").Attribute("value").Value;

                //getting temperature description from xml
                Temperature temp = new Temperature(timeNode.Element("temperature").Attribute("unit").Value,
                    Convert.ToDouble(timeNode.Element("temperature").Attribute("value").Value),
                    Convert.ToDouble(timeNode.Element("temperature").Attribute("min").Value),
                    Convert.ToDouble(timeNode.Element("temperature").Attribute("max").Value));

                //construct WeatherData object with all data
                wd = new WeatherData(location, time, temp, clouds);
            }
            catch (System.Net.WebException e)
            {
                throw new WeatherDataServiceException("Problem with downloading xml", e);
            }
            catch (System.Xml.XmlException e)
            {
                throw new WeatherDataServiceException("Problem with parsing xml", e);
            }
            catch (System.NullReferenceException e)
            {
                throw new WeatherDataServiceException("Element/Attribute name is incorrect", e);
            }

            return wd;
        }
    }
}
