using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class SupervisorEngineerBll
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor
        public SupervisorEngineerBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods


        #endregion

        #region Helper

        internal SupervisorEngineer ConvertToDataAccessModel(SupervisorEngineerInfo businessModel)
        {
            if (businessModel == null) return null;
            return new SupervisorEngineer()
            {
                Id = businessModel.Id,
                EngineeringCode = businessModel.EngineeringCode,
                FirstName = businessModel.FirstName,
                LastName = businessModel.LastName,
                PhoneNumber = businessModel.PhoneNumber
            };
        }

        internal SupervisorEngineerInfo ConvertToBusinessModel(SupervisorEngineer dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new SupervisorEngineerInfo()
            {
                Id = dataAccessModel.Id,
                EngineeringCode = dataAccessModel.EngineeringCode,
                FirstName = dataAccessModel.FirstName,
                LastName = dataAccessModel.LastName,
                PhoneNumber = dataAccessModel.PhoneNumber
            };
        }
        #endregion

    }
}
