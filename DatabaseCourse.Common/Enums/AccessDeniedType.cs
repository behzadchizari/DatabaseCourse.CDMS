using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.Common.Enums
{
    public enum AccessDeniedType
    {
        [EnumDescription("")]
        Null = 0,
        [EnumDescription("کاربر لاگین نشده")]
        NotLogined = 10,
        [EnumDescription("مورد امنیتی در فایل کانفیگ موجود نیست")]
        NoSecurityConfig = 20,
        [EnumDescription("دسترسی به صفحه امکانپذیر نیست")]
        NoAccessToPage = 30,
        [EnumDescription("کاربر لاگین شده")]
        UserLogined = 40,
        [EnumDescription("تجاوز کاربر از حد مجاز")]
        ExceededLimits = 40,
    }
}
