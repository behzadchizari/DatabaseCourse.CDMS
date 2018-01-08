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
        internal CooperationContract ConvertToDataAccessModel(CooperationContractInfo businessModel)
        {
            if (businessModel == null) return null;
            return new CooperationContract()
            {
                Id = businessModel.Id,
                ProjectId = businessModel.ProjectId,
               ContractorId = businessModel.ContractorId,
               EndDate = businessModel.EndDate,
               StartDate = businessModel.StartDate,
               WageType = businessModel.WageType
            };
        }

        internal CooperationContractInfo ConvertToBusinessModel(CooperationContract dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new CooperationContractInfo()
            {
                Id = dataAccessModel.Id,
                ProjectId = dataAccessModel.ProjectId,
                ContractorId = dataAccessModel.ContractorId,
                EndDate = dataAccessModel.EndDate,
                StartDate = dataAccessModel.StartDate,
                WageType = dataAccessModel.WageType
            };
        }
        #endregion
    }
}
