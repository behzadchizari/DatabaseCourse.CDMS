using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class SupervisorEngineerBll
    {
        #region Variables

        private SupervisorEngineerDA da = new SupervisorEngineerDA();

        #endregion

        #region Ctor


        #endregion

        #region Methods

        public int FindSupervisorEngineerInfoByName(string name)
        {
            var se = da.FindByName(name);
            return se.Id;
        }
        public SupervisorEngineerInfo GetSupervisorEngineerInfoByName(string name)
        {
            return ConvertToBusinessModel(da.GetByName(name));
        }

        public List<SupervisorEngineerInfo> GetAllSupervisorEngineerInfos()
        {
            var se = da.GetAll();
            var result = new List<SupervisorEngineerInfo>();
            foreach (var item in se)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }

        public int UpdateExisting(SupervisorEngineerInfo supervisorEng)
        {
            return da.Update(ConvertToDataAccessModel(supervisorEng));
        }
        #endregion

        #region Helper

        internal static SupervisorEngineer ConvertToDataAccessModel(SupervisorEngineerInfo businessModel)
        {
            if (businessModel == null) return null;
            return new SupervisorEngineer()
            {
                Id = businessModel.Id,
                EngineeringCode = businessModel.EngineeringCode,
                FullName = businessModel.FullName,
                PhoneNumber = businessModel.PhoneNumber
            };
        }

        internal static SupervisorEngineerInfo ConvertToBusinessModel(SupervisorEngineer dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new SupervisorEngineerInfo()
            {
                Id = dataAccessModel.Id,
                EngineeringCode = dataAccessModel.EngineeringCode,
                FullName = dataAccessModel.FullName,
                PhoneNumber = dataAccessModel.PhoneNumber
            };
        }
        #endregion

    }
}
