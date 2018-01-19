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

        private CurrentUser _currentUser = null;
        private SupervisorEngineerDA da = new SupervisorEngineerDA();

        #endregion

        #region Ctor
        public SupervisorEngineerBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        public int FindSupervisorEngineerInfoByName(string name)
        {
            var se = da.FindByName(name);
            return se.Id;
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
        #endregion

        #region Helper

        internal SupervisorEngineer ConvertToDataAccessModel(SupervisorEngineerInfo businessModel)
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

        internal SupervisorEngineerInfo ConvertToBusinessModel(SupervisorEngineer dataAccessModel)
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
