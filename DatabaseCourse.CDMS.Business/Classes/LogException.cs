using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.Classes
{
    public class LogException
    {
        public static void AddLogData(string message, CurrentUser currentUser)
        {
            var logBll = new LogBLL(currentUser);
            try
            {
                var loginfo = new LogExceptionInfo()
                {
                    DateTime = DateTime.Now,
                    LogType = Common.Enums.LogTypeEnum.Log,
                    Message = message,
                    StackTrace = null,
                    UserId = currentUser?.Id ?? null
                };
                logBll.AddLogException(loginfo);
            }
            catch (Exception)
            {
            }
        }
        
        public static void AddExceptionData(Exception exception, CurrentUser currentUser)
        {
            var logBll = new LogBLL(currentUser);
            try
            {
                var loginfo = new LogExceptionInfo()
                {
                    DateTime = DateTime.Now,
                    LogType = Common.Enums.LogTypeEnum.Exception,
                    Message = ExceptionUtility.GetAllInnerException(exception),
                    StackTrace = exception.StackTrace.Replace(")",$"){Environment.NewLine}"),
                    UserId = currentUser?.Id ?? null
                };
                logBll.AddLogException(loginfo);
            }
            catch (Exception)
            {
            }
        }

    }
}
