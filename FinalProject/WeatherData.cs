using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provides representation of weather data and its properties
    /// </summary>
    public class WeatherData 
    {
        /// <summary>
        /// The class constructor. 
        /// </summary>
        public WeatherData(Location loc, Time time, Temperature temp, string clouds) 
        {
            this.Loc = loc;
            this.Time = time;
            this.Temperature = temp;
            this.Clouds = clouds;
        }

        /// <summary>
        /// Location for the specific data
        /// </summary>
        public Location Loc { get; set; }

        /// <summary>
        /// Time of measurmenet
        /// </summary>
        public Time Time { get; set; }

        /// <summary>
        /// Temperature object
        /// </summary>
        public Temperature Temperature { get; set; }

        /// <summary>
        /// Clouds description
        /// </summary>
        public string Clouds { get; set; }

         /// <summary>
        /// Represent object as string 
        /// </summary>
        public override string ToString()
        {
            return "Weather Data: \n" + this.Loc + "\n" + this.Time + "\n" + this.Temperature + "\n" + this.Clouds; 
        }

        /// <summary>
        /// Return comparing results
        /// </summary>
        public bool Equals(WeatherData wd)
        {
            // If parameter is null return false:
            if ((object)wd == null)
            {
                return false;
            }

            // Return true if the fields match:
            return ((this.Clouds.Equals(wd.Clouds, StringComparison.Ordinal)) && (this.Time.Equals(wd.Time)) &&
                (this.Loc.Equals(wd.Loc)) && (this.Temperature.Equals(wd.Temperature)));
        }
    }
}
