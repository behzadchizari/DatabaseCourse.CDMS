using System.Collections.Generic;
using System.Linq;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class ContractorBll
    {

        #region Variables

        private ContractorDA _contractorDa = new ContractorDA();
        #endregion

        #region Ctor

        public List<ContractorInfo> GetAllContractorInfos()
        {
            var all = _contractorDa.GetAll();
            var result = new List<ContractorInfo>();
            foreach (var item in all)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }
        public ContractorInfo GetContractorById(int id)
        {
            return ConvertToBusinessModel(_contractorDa.GetById(id));
        }

        public int AddNewContractorInfo(ContractorInfo contractorInfo)
        {
            return _contractorDa.Add(ConvertToDataAccessModel(contractorInfo));
        }
        public int UpdateContractorInfo(ContractorInfo contractorInfo)
        {
            return _contractorDa.Update(ConvertToDataAccessModel(contractorInfo));
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
