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

        public SupervisorEngineer ConvertToDataAccessModel(SupervisorEngineerInfo businessModel)
        {
            throw new System.NotImplementedException();
        }

        public SupervisorEngineerInfo ConvertToBusinessModel(SupervisorEngineer dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
