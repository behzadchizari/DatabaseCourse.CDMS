﻿using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.Common.Enums
{
    public enum UserRoleEnum
    {
        //Use Non-Dividable to 10 for items which you dont want to see in view(User/Edit)
        [EnumDescription("")]
        Null = 0,
        [EnumDescription("کاربر لاگین نشده")]
        Guest = 5,
        [EnumDescription("همه کاربران")]
        All = 6,
        [EnumDescription("راهبر ارشد سیستم")]
        SuperAdmin = 10,
        [EnumDescription("راهبر سیستم")]
        Admin = 20,
        [EnumDescription("سرپرست کارگاه")]
        Supervisor = 30,
        [EnumDescription("کارمند مدیر فنی")]
        TechOfficer = 40,
        [EnumDescription("مدیر مالی")]
        FinManager = 50,
        [EnumDescription("مدیرعامل")]
        CEO = 60
    }
}