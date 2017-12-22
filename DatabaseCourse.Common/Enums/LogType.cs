using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Enums
{
    public enum LogTypeEnum
    {
        [EnumDescription("")]
        Null = 0,
        [EnumDescription("خطای سیستمی")]
        Exception = 10,
        [EnumDescription("گزارش رخداد")]
        Log = 20
    }
}
