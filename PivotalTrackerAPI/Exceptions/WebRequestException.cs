using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PivotalTrackerAPI.Exceptions {
    public class WebRequestException : System.Exception {

        #region Constructor
        public WebRequestException(string message) : base(message) { 
            
        }
        #endregion Constructor

        #region Properties
        public string ErrorXml { get; set; }
        public int StatusCode { get; set; }
        #endregion Properties
    }
}
