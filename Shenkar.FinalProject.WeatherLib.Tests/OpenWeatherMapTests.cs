using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shenkar.FinalProject.WeatherLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Net;

namespace Shenkar.FinalProject.WeatherLib.Tests
{

    /// <summary>
    /// This class provide unit tests for IWeatherDataService methods and is intended
    ///to contain all IWeatherDataService Unit Tests
    /// </summary>
    [TestClass()]
    public class OpenWeatherMapTests
    {
        /// <summary>
        /// Testing GetWeatherData(Location) method - Expected: same data
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataLocTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target =  n.GetWeatherData(new Location("Haifa","il"));
            WeatherData wd = GetWeatherDataForTest("http://api.openweathermap.org/data/2.5/forecast?q=haifa,il&mode=xml");
            
            //compare the two WeatherData objects
            Assert.IsTrue(wd.Equals(target));
        }

        /// <summary>
        /// Testing GetWeatherData(Location) method with wrong parameters - Expected: null object
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataLocNullTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target = n.GetWeatherData(new Location("0000000", ""));
            Assert.IsNull(target);
        }

        /// <summary>
        /// Testing GetWeatherData(int) method - Expected: same data
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataIdTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target = n.GetWeatherData(524901);
            WeatherData wd = GetWeatherDataForTest("http://api.openweathermap.org/data/2.5/forecast?id=524901&mode=xml");

            //compare the two WeatherData objects
            Assert.IsTrue(wd.Equals(target));
        }

        /// <summary>
        /// Testing GetWeatherData(int) method with wrong parameters - Expected: null object
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataIdNullTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target = n.GetWeatherData(0000000);
            Assert.IsNull(target);
        }

        /// <summary>
        /// Testing GetWeatherData(GeoCoordinations) method - Expected: same data
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataGeoTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target = n.GetWeatherData(new GeoCoordinations(35, 139));
            WeatherData wd = GetWeatherDataForTest("http://api.openweathermap.org/data/2.5/forecast?lat=35&lon=139&mode=xml");
    
            //compare the two WeatherData objects
            Assert.IsTrue(wd.Equals(target));
        }

        /// <summary>
        /// Testing GetWeatherData(GeoCoordinations) method with wrong parameters - Expected: null object
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataGeoNullTest()
        {
            IWeatherDataService n = new WeatherDataServiceFactory().getWeatherDataService(1);
            WeatherData target = n.GetWeatherData(new GeoCoordinations(10000000, 10000000));
            Assert.IsNull(target);
        }

        private WeatherData GetWeatherDataForTest(string url)
        {
            string xml = new WebClient().DownloadString(url);
            XDocument xdoc = XDocument.Parse(xml);

            //getting values from xml
            var path = xdoc.Element("weatherdata").Element("location");
            Location location = new Location(path.Element("name").Value, path.Element("country").Value);
            path = xdoc.Element("weatherdata").Element("forecast").Element("time");
            Time time = new Time(path.Attribute("from").Value, path.Attribute("to").Value);
            string clouds = path.Element("clouds").Attribute("value").Value;
            Temperature temp = new Temperature(path.Element("temperature").Attribute("unit").Value,
                    Convert.ToDouble(path.Element("temperature").Attribute("value").Value),
                    Convert.ToDouble(path.Element("temperature").Attribute("min").Value),
                    Convert.ToDouble(path.Element("temperature").Attribute("max").Value));
           return new WeatherData(location, time, temp, clouds);
        }
    }
}
