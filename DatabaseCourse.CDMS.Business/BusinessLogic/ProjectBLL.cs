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
        public ProjectBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        public int AddNewProject(ProjectInfo project)
        {
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
        public ProjectInfo GetByProjectId(int projectId)
        {
            return ConvertToBusinessModel(projectDA.GetById(projectId).FirstOrDefault());
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
                    GroundOwner = dataAccessModel.GroundOwner
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
                    Address = businessModel.Address
                };
            }
            return null;
        }

        #endregion
    }
}
