using System.Collections.Generic;
using System.Linq;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class CooperationContractBll
    {
        #region Variables

        private CooperationContractDA ContractDa = new CooperationContractDA();

        #endregion

        #region Ctor

        #endregion

        #region Methods


        public List<CooperationContractInfo> GetCooperationContractInfosByProjectId(int id)
        {
            var res = ContractDa.GetAll().Where(x => x.ProjectId == id);
            var result = new List<CooperationContractInfo>();
            foreach (var item in res)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }


        public List<CooperationContractInfo> GetCooperationContractInfosByContractorId(int id)
        {
            var res = ContractDa.GetAll().Where(x => x.ContractorId == id);
            var result = new List<CooperationContractInfo>();
            foreach (var item in res)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }


        public int AddNewCooperationContract(CooperationContractInfo cooperationContractInfo)
        {
            return ContractDa.Add(ConvertToDataAccessModel(cooperationContractInfo));
        }

        public int UpdateExsisting(CooperationContractInfo cooperationContractInfo)
        {
            return ContractDa.Update(ConvertToDataAccessModel(cooperationContractInfo));
        }
        #endregion

        #region Helper
        internal static CooperationContract ConvertToDataAccessModel(CooperationContractInfo businessModel)
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

        internal static CooperationContractInfo ConvertToBusinessModel(CooperationContract dataAccessModel)
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
