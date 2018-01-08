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

        internal Contractor ConvertToDataAccessModel(ContractorInfo businessModel)
        {
            return businessModel == null
                ? null
                : new Contractor()
                {
                    Id = businessModel.Id,
                    Contact = businessModel.Contact,
                    FirstCooperationDate = businessModel.FirstCooperationDate,
                    FirstName = businessModel.FirstName,
                    InsuranceNo = businessModel.InsuranceNo,
                    LastName = businessModel.LastName,
                    Nationalid = businessModel.Contact
                };
        }

        internal ContractorInfo ConvertToBusinessModel(Contractor dataAccessModel)
        {
            return dataAccessModel == null
                ? null
                : new ContractorInfo()
                {
                    Id = dataAccessModel.Id,
                    Contact = dataAccessModel.Contact,
                    FirstCooperationDate = dataAccessModel.FirstCooperationDate,
                    FirstName = dataAccessModel.FirstName,
                    InsuranceNo = dataAccessModel.InsuranceNo,
                    LastName = dataAccessModel.LastName,
                    NationalId = dataAccessModel.Nationalid
                };
            }
        #endregion
    }
}
