using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class ExpenseInfo
    {

        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public ExpenseInfo(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        #endregion

        #region Helper
        public Expense ConvertToDataAccessModel(ExpenseInfo businessModel)
        {
            throw new System.NotImplementedException();
        }

        public ExpenseInfo ConvertToBusinessModel(Expense dataAccessModel)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
