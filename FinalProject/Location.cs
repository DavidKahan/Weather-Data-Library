using System;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provides representation of location by city and cuntry
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The class constructor. 
        /// </summary>
        public Location(string city, string country){
            this.City = city;
            this.Country = country;
        }

        /// <summary>
        /// Location city property
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// Location country property
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        /// Represent object as string 
        /// </summary>
        public override string ToString()
        {
            return "Location: " + this.City + ", " + this.Country;
        }

        /// <summary>
        /// Return comparing results
        /// </summary>
        public bool Equals(Location loc)
        {
            // If parameter is null return false:
            if ((object)loc == null)
            {
                return false;
            }

            // Return true if the fields match:
            return ((this.Country == loc.Country) && (this.City.Equals(loc.City, StringComparison.Ordinal)));
        }
    }
}
