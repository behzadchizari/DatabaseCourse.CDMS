using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class ContractorBll
    {

        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public ContractorBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods


        #endregion

        #region Helper
        public Contractor ConvertToDataAccessModel(ContractorInfo businessModel)
        {
            throw new System.NotImplementedException();
        }

        public ContractorInfo ConvertToBusinessModel(Contractor dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
