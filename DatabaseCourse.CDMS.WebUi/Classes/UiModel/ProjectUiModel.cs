using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using static DatabaseCourse.CDMS.WebUi.Controllers.ProjectController;

namespace DatabaseCourse.CDMS.WebUi.Classes.UiModel
{
    public class ProjectUiModel
    {
        ProjectBll projectBll = new ProjectBll();


        public int Id { get; set; }
        public string GroundType { get; set; }
        public string ProductionLicense { get; set; }
        public string SupervisorEngineerFullName { get; set; }
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
            var result = new List<Exception>();

            var proj = projectBll.GetprojectByTitle(this.Title);

            if (fn == EditProjectFunctionEnum.Add)
            {
                if (proj != null)
                    result.Add(new Exception("پروژه با این عنوان قبلا وجود داشته"));
            }
            else if (fn == EditProjectFunctionEnum.Edit)
            {
                if (Id != 0)
                {
                    if (proj != null)
                    {
                        if (proj.Title != Title)
                        {
                            result.Add(new Exception("پروژه با این عنوان قبلا وجود داشته"));
                        }
                    }
                }
            }


            return result;
        }

        private void MakeDefault()
        {
            Id = 0;
            GroundType = "";
            ProductionLicense = "";
            SupervisorEngineerFullName = "";
            Client = "";
            Address = "";
            GroundOwner = "";
            Title = "";
            Name = "";
        }
    }
}