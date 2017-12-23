using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class LogExceptionInfo
    {
        #region Properties

        public int Id { get; set; }

        public string Type { get; set; }

        public LogTypeEnum LogType
        {
            get
            {
                return EnumUtility.GetEnumByTitle<LogTypeEnum>(Type);
            }
        }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? DateTime { get; set; }

        public int? UserId { get; set; }

        public UserInfo User { get; set; }

        #endregion
        



    }
}
