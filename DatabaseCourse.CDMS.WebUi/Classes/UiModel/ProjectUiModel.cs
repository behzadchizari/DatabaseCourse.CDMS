using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DatabaseCourse.CDMS.WebUi.Controllers.ProjectController;

namespace DatabaseCourse.CDMS.WebUi.Classes.UiModel
{
    public class ProjectUiModel
    {

        public int Id { get; set; }
        public string GroundType { get; set; }
        public string ProductionLicense { get; set; }
        public string SupervisorEngineerId { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string GroundOwner { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public ProjectUiModel()
        {
            MakeDefault();
        }

        public List<Exception> ChackModel(EditProjectFunctionEnum fn)
        {
            return new List<Exception>();
        }

        private void MakeDefault()
        {
            Id = 0;
            GroundType = "";
            ProductionLicense = "";
            SupervisorEngineerId = "";
            Client = "";
            Address = "";
            GroundOwner = "";
            Title = "";
            Name = "";
        }
    }
}