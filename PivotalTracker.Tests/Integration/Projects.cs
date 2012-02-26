using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotalTrackerAPI.Domain.Model;

namespace PivotalTracker.Tests.Integration {
    [TestClass]
    public class Projects : Base {

        #region Properties
        public int ProjectID { get; set; }
        #endregion Properties

        [TestInitialize]
        public override void Setup() {
            base.Setup();

            this.ProjectID = 482289;
        }

        [TestMethod]
        public void integration_projects_get_projects_for_user() {

            IList<PivotalProject> projects = PivotalProject.FetchProjects(this.CurrentUser);

            Assert.IsTrue(projects.Count > 0);
        }

        [TestMethod]
        public void integration_projects_get_project_by_id() {

            PivotalProject project = PivotalProject.FetchProject(this.CurrentUser, this.ProjectID);
            Assert.IsNotNull(project);
        }

        [TestMethod]
        public void integration_projects_get_project_by_bad_id() {

            try {
                PivotalProject project = PivotalProject.FetchProject(this.CurrentUser, 1);
                Assert.IsNull(project);
            }
            catch (PivotalTrackerAPI.Exceptions.WebRequestException ex) {
                Assert.AreEqual(404, ex.StatusCode);
            }
        }

        [TestMethod]
        public void integration_projects_get_project_by_id_with_stories() {

            PivotalProject project = PivotalProject.FetchProject(this.CurrentUser, this.ProjectID, true);
            Assert.IsTrue(project.Stories.Count > 0);
        }
    }
}
