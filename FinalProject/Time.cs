using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provides representation of time element and its attributes
    /// </summary>
    public class Time
    {
        /// <summary>
        /// The class constructor. 
        /// </summary>
        public Time(string from, string to)
        {
            this.From = from;
            this.To = to;
        }

        /// <summary>
        /// Time for the start of measurement
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Time for the end of measurement
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Represent object as string 
        /// </summary>
        public override string ToString()
        {
            return "Time: From=" + this.From + ", To=" + this.To;
        }

        /// <summary>
        /// Return comparing results
        /// </summary>
        public bool Equals(Time time)
        {
            // If parameter is null return false:
            if ((object)time == null)
            {
                return false;
            }

            // Return true if the fields match:
            return ((this.From.Equals(time.From, StringComparison.Ordinal)) && (this.To.Equals(time.To, StringComparison.Ordinal)));
        }
    }
}
