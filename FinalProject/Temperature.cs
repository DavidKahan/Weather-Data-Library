using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provides representation of temperature element and its attributes
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// The class constructor. 
        /// </summary>
        public Temperature(string unit, double val, double min, double max)
        {
            this.TemperatureUnit = unit;
            this.TemperatureValue = val;
            this.TemperatureMin = min;
            this.TemperatureMax = max;
        }

        /// <summary>
        /// Unit used for temperature measurement
        /// </summary>
        public string TemperatureUnit { get; set; }

        /// <summary>
        /// Value of temperature
        /// </summary>
        public double TemperatureValue { get; set; }

        /// <summary>
        /// Minimum value of temperature
        /// </summary>
        public double TemperatureMin { get; set; }

        /// <summary>
        /// Maximum value of temperature
        /// </summary>
        public double TemperatureMax { get; set; }

        /// <summary>
        /// Represent object as string 
        /// </summary>
        public override string ToString()
        {
            return "Temperature: Unit=" + this.TemperatureUnit + ", Value=" + this.TemperatureValue + 
                    "Min="+this.TemperatureMin + "Max = " + this.TemperatureMax;
        }

        /// <summary>
        /// Return comparing results
        /// </summary>
        public bool Equals(Temperature temp)
        {
            // If parameter is null return false:
            if ((object)temp == null)
            {
                return false;
            }

            // Return true if the fields match:
            return ((this.TemperatureMax == temp.TemperatureMax) && (this.TemperatureMin == temp.TemperatureMin) &&
               (this.TemperatureValue == temp.TemperatureValue) && (this.TemperatureUnit.Equals(temp.TemperatureUnit, StringComparison.Ordinal)));
        }
    }
}
