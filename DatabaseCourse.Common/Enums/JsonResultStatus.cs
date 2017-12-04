using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Enums
{
    public enum JsonResultStatus
    {
        [EnumDescription("")]
        Nullable =0,
        [EnumDescription("موفق")]
        Ok = 10,
        [EnumDescription("خطا")]
        Exception = 20,
        [EnumDescription("کاربر یافت نشد")]
        UserNotFound = 30,
        [EnumDescription("وجود کاربر لاگین شده")]
        AlreadyLogedIn= 35,
        [EnumDescription("نبود دسترسی")]
        AccessDenied = 40,


    }
}
