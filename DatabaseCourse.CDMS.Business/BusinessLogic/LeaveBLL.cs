using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class LeaveInfo
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public LeaveInfo(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        #endregion

        #region Helper
        public Leave ConvertToDataAccessModel(LeaveInfo businessModel)
        {
            throw new System.NotImplementedException();
        }

        public LeaveInfo ConvertToBusinessModel(Leave dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
