using System;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// Provides representation of geographic coordination
    /// </summary>
    public class GeoCoordinations
    {
        /// <summary>
        /// The class constructor. 
        /// </summary>
        public GeoCoordinations(double latitude, double longtitude)
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
        }

        /// <summary>
        /// Coordination latitude property 
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Coordination longtitude property
        /// </summary>
        public double Longtitude { get; set; }

        /// <summary>
        /// Represent object as string 
        /// </summary>
        public override string ToString()
        {
            return "Geographic coordinats: Latitude:" + this.Latitude + ", Longtitude:" + this.Longtitude;
        }
    }
}
