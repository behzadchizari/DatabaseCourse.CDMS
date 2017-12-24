using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Utility;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class LogExceptionInfo
    {
        private LogTypeEnum _LogType = LogTypeEnum.Null;
        #region Properties

        public int Id { get; set; }

        public string Type { get; set; }

        public LogTypeEnum LogType
        {
            set
            {
                _LogType = value;
                Type = value.ToString();
            }
            get
            {
                if (_LogType != LogTypeEnum.Null) { return _LogType; }
                return EnumUtility.GetEnumByTitle<LogTypeEnum>(Type);
            }
        }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? DateTime { get; set; }

        public string DateTimeStr => DateTimeUtility.ConvertToPersianCalender(DateTime ?? System.DateTime.MinValue);

        public int? UserId { get; internal set; }
        
        #endregion




    }
}
