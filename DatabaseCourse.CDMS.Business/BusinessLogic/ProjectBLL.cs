using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class ProjectBll
    {
        #region Variables
        private CurrentUser _currentUser = null;
        private ProjectDA projectDA = new ProjectDA();
        #endregion

        #region Ctor
        //public ProjectBll(CurrentUser currentUser)
        //{
        //    _currentUser = currentUser;
        //}

        #endregion

        #region Methods

        public int AddNewProject(ProjectInfo project)
        {
                project.CreationDate = DateTime.Now;
                project.LastModifiedDate = DateTime.Today;
                return projectDA.Add(ConvertToDataAccessModel(project));
        }
        public int UpdateExistingProject(ProjectInfo project)
        {
            return projectDA.Update(ConvertToDataAccessModel(project));
        }
        public List<ProjectInfo> GetAllProject()
        {
            var result = new List<ProjectInfo>();
            var daList = projectDA.GetAll();
            foreach (var item in daList)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }

        public int GetCountOfAllNonTerminateProjects()
        {
            return projectDA.GetAll().Count(x => x.EndingDate == null);
        }
        public ProjectInfo GetprojectByTitle(string title)
        {
            return ConvertToBusinessModel(projectDA.GetByTitle(title));
        }
        public int GetCountOfAllProjects()
        {
            return projectDA.GetAll().Count();
        }

        public List<ProjectInfo> GetAllProjectsByUserId(int id)
        {
            var result = new List<ProjectInfo>();
            var daList = projectDA.GetByUserId(id);
            foreach (var item in daList)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }


        public int GetCountOfAllProjectsByUserId(int id)
        {
            return projectDA.GetAll().Count(x => x.UserId == id);
        }
        public int GetNonTerminateCountOfAllProjectsByUserId(int id)
        {
            return projectDA.GetAll().Count(x => x.UserId == id && x.EndingDate == null);
        }

        public ProjectInfo GetByProjectId(int projectId)
        {
            return ConvertToBusinessModel(projectDA.GetById(projectId));
        }

        #endregion

        #region Helper

        internal static ProjectInfo ConvertToBusinessModel(Project dataAccessModel)
        {
            if (dataAccessModel != null)
            {
                return new ProjectInfo()
                {
                    CreationDate = dataAccessModel.CreationDate,
                    EndingDate = dataAccessModel.EndingDate,
                    GroundType = dataAccessModel.GroundType,
                    Id = dataAccessModel.Id,
                    LastModifiedDate = dataAccessModel.LastModifiedDate,
                    ProductionLicense = dataAccessModel.ProductionLicense,
                    UserId = dataAccessModel.UserId,
                    SupervisorEngineerId = dataAccessModel.SupervisorEngineerId,
                    Address = dataAccessModel.Address,
                    Client = dataAccessModel.Client,
                    GroundOwner = dataAccessModel.GroundOwner,
                    Name = dataAccessModel.Name,
                    Title = dataAccessModel.Title
                };
            }
            return null;
        }
        internal static Project ConvertToDataAccessModel(ProjectInfo businessModel)
        {
            if (businessModel != null)
            {
                return new Project()
                {
                    UserId = businessModel.UserId,
                    ProductionLicense = businessModel.ProductionLicense,
                    LastModifiedDate = businessModel.LastModifiedDate,
                    Id = businessModel.Id,
                    GroundType = businessModel.GroundType,
                    EndingDate = businessModel.EndingDate,
                    CreationDate = businessModel.CreationDate,
                    SupervisorEngineerId = businessModel.SupervisorEngineerId,
                    GroundOwner = businessModel.GroundOwner,
                    Client = businessModel.Client,
                    Address = businessModel.Address,
                    Name = businessModel.Name,
                    Title = businessModel.Title
                };
            }
            return null;
        }

        #endregion
    }
}
