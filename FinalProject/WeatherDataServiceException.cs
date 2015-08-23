using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shenkar.FinalProject.WeatherLib
{
    /// <summary>
    /// This class extends from System.ApplicationException and provide a WeatherDataServiceException to describe errors.
    /// </summary>
    public class WeatherDataServiceException : System.ApplicationException
    {
        /// <summary>
        /// The class basic constructor. 
        /// </summary>
        public WeatherDataServiceException() : base() { }

        /// <summary>
        /// The class constructor to display error message. 
        /// </summary>
        public WeatherDataServiceException(string message) : base(message) { }

        /// <summary>
        /// The class constructor to display error message and original exception. 
        /// </summary>
        public WeatherDataServiceException(string message, System.Exception inner) : base(message, inner) { }
        
        /// <summary>
        ///  A constructor is needed for serialization when an exception propagates from a remoting server to the client.  
        /// </summary>
        protected WeatherDataServiceException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
