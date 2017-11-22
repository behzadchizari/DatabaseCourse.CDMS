using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.Common.Enums
{
    public enum UserRoleEnum
    {
        [EnumDescription("")]
        Null = 0,
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