using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Enums
{
    public enum AttachmentCategoryEnum
    {
        [EnumDescription("")]
        Null =0,
        [EnumDescription("نقشه ها")]
        Map = 10,
        [EnumDescription("آزمایشات")]
        Examination = 20,
        [EnumDescription("قراردادها")]
        Contract = 30,
        [EnumDescription("جوازها")]
        License = 40,
        [EnumDescription("وکالتنامه ها")]
        PowerOfAttorney = 50,
        [EnumDescription("تاییدهای مهندس ناظر")]
        SupervisorEngineerConfirmation = 60,



        

    }
}
