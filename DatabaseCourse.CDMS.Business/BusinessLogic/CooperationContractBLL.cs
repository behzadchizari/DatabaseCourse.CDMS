using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class CooperationContractBll
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public CooperationContractBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods


        #endregion

        #region Helper
        public CooperationContract ConvertToDataAccessModel(CooperationContractInfo businessModel)
        {
            throw new System.NotImplementedException();
        }

        public CooperationContractInfo ConvertToBusinessModel(CooperationContract dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
