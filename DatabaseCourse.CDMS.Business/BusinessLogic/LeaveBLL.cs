using System;
using System.Collections.Generic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Utility;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class LeaveBll
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        #endregion

        #region Methods

        public List<LeaveInfo> GetByCooperationContractId(int cooperationContractId)
        {
            var list = new LeaveDA().GetByCooperationContractId(cooperationContractId);
            var result = new List<LeaveInfo>();
            foreach (var item in list)
            {
                result.Add(ConvertToBusinessModel(item));
            }
            return result;
        }


        public Dictionary<int, List<LeaveInfo>> GetGroupByMounth(List<LeaveInfo> leaveList)
        {
            var result = new Dictionary<int, List<LeaveInfo>>();
            if (leaveList.Count > 0)
            {
                foreach (var item in leaveList)
                {

                    if (item.StartDateTime == null) continue;
                    var pcDate = DateTimeUtility.GetDateInfoSeperated(DateTimeUtility.ConvertToPersianCalenderGetDate(item.StartDateTime??DateTime.Now));
                    
                    result[pcDate["month"]].Add(item);
                }
            }
            else
            {
                return new Dictionary<int, List<LeaveInfo>>();
            }
            return result;
        }


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
