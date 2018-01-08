using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class LeaveBll
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public LeaveBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        #endregion

        #region Helper
        internal Leave ConvertToDataAccessModel(LeaveInfo businessModel)
        {
            if (businessModel == null) return null;
            return new Leave()
            {
                Id = businessModel.Id,
                CooperationContractId = businessModel.CooperationContractId,
                EndDateTime = businessModel.EndDateTime,
                StartDateTime = businessModel.StartDateTime
            };
        }

        internal LeaveInfo ConvertToBusinessModel(Leave dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new LeaveInfo()
            {
                Id = dataAccessModel.Id,
                CooperationContractId = dataAccessModel.CooperationContractId,
                EndDateTime = dataAccessModel.EndDateTime,
                StartDateTime = dataAccessModel.StartDateTime
            };
        }
        #endregion
    }
}
