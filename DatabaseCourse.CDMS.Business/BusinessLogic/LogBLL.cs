using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class LogBLL
    {
        #region Properties

        private CurrentUser _currentUser = null;

        #endregion

        #region ctor
        public LogBLL(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        #endregion

        #region Methods

        public Exception AddLogException(LogExceptionInfo logExceptionInfo)
        {
            //var exData = new Exception();
            try
            {
                var da = new LogExceptionDA();
                logExceptionInfo.UserId = _currentUser?.Id ;
                var add = da.Add(ConvertToDataAccessModel(logExceptionInfo));
                if (add > 0)
                    return null;
                else
                    return new Exception("لاگ ثبت نشد");
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public List<LogExceptionInfo> GetAllLogAndExceptions()
        {
            try
            {
                var da = new LogExceptionDA();
                var allLogs = da.GetAll();
                var result = new List<LogExceptionInfo>();
                foreach (var item in allLogs)
                {
                    result.Add(ConvertToBusinessModel(item));
                }
                return result;
            }
            catch (Exception)
            {
                return new List<LogExceptionInfo>();
            }
        }
        public List<LogExceptionInfo> GetAllByType(LogTypeEnum logTypeEnum)
        {
            try
            {
                var da = new LogExceptionDA();
                var allLogs = da.GetAll().Where(x=>x.Type == logTypeEnum.ToString());
                var result = new List<LogExceptionInfo>();
                foreach (var item in allLogs)
                {
                    result.Add(ConvertToBusinessModel(item));
                }
                return result;
            }
            catch (Exception)
            {
                return new List<LogExceptionInfo>();
            }
        }
        public int GetAllCount()
        {
            try
            {
                var da = new LogExceptionDA();
                var allLogs = da.GetAll();
                return allLogs.Count();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int GetCountByType(LogTypeEnum logTypeEnum)
        {
            try
            {
                var da = new LogExceptionDA();
                var allLogs = da.GetAll();
                return allLogs.Where(x=>x.Type == logTypeEnum.ToString()).Count();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Helpers

        internal static LogException ConvertToDataAccessModel(LogExceptionInfo logExceptionInfo)
        {
            if (logExceptionInfo != null)
            {
                return new LogException()
                {
                    Id = logExceptionInfo.Id,
                    DateTime = logExceptionInfo.DateTime,
                    Type = logExceptionInfo.Type,
                    User_Id = logExceptionInfo.UserId,
                    Message = logExceptionInfo.Message,
                    StackTrace = logExceptionInfo.StackTrace
                };
            }
            return null;
        }
        internal static LogExceptionInfo ConvertToBusinessModel(LogException logException)
        {
            if (logException != null)
            {
                return new LogExceptionInfo()
                {
                    Id = logException.Id,
                    DateTime = logException.DateTime,
                    Type = logException.Type,
                    UserId = logException.User_Id,
                    Message = logException.Message,
                    StackTrace = logException.StackTrace
                };
            }
            return null;
        }

        #endregion
    }
}
