using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTrackerAPI.Domain.Model;
using PivotalTrackerAPI.Exceptions;
using System.Configuration;

namespace PivotalTracker.Tests.Integration {
    [TestClass]
    public class Users {

        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        #endregion Properties

        [TestInitialize]
        public void Setup() {
            this.UserName = ConfigurationManager.AppSettings["username"];
            this.Password = ConfigurationManager.AppSettings["password"];
        }

        [TestMethod]
        public void integration_users_get_by_creds() {

            PivotalUser user = PivotalUser.GetUserFromCredentials(this.UserName, this.Password);
            Assert.IsNotNull(user);

        }

        [TestMethod]
        public void integration_users_get_with_bad_creds() {

            try {
                PivotalUser user = PivotalUser.GetUserFromCredentials("notgooduser", "badpassword");
            }
            catch (WebRequestException ex) {
                Assert.AreEqual(401, ex.StatusCode);
            }
        }

        [TestMethod]
        public void integration_users_get_projects_for_user() {

            PivotalUser user = PivotalUser.GetUserFromCredentials(this.UserName, this.Password);
            user.LoadProjects();

            Assert.IsTrue(user.Projects.Count > 0);
        }
    }
}
