using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTrackerAPI.Domain.Model;
using System.Configuration;

namespace PivotalTracker.Tests.Integration {
    [TestClass]
    public class Base {

        #region Properties
        public PivotalUser CurrentUser { get; set; }
        #endregion Properties

        [TestInitialize]
        public virtual void Setup() {
            this.CurrentUser = PivotalUser.GetUserFromCredentials(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }
    }
}
