using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Enums
{
    public enum AttachmentTypeEnum
    {

        [EnumDescription("")]
        Null = 0,

        [EnumDescription("سازه")]
        Structure = 11,
        [EnumDescription("معماری")]
        Architecture = 12,
        [EnumDescription(" طراحی نما")]
        FacadeDesign =13,
        [EnumDescription("تاسیسات")]
        Installations = 14,

         
        [EnumDescription("مکانیک خاک")]
         SoilMechanics =21,
        [EnumDescription("تست فولاد")]
        SteelTest=22,
        [EnumDescription("تست بتن")]
        ConcreteTest = 23,
        [EnumDescription("تست جوش")]
        WeldingTest = 24,


        [EnumDescription("جواز ساخت")]
        ProductionLicense = 41,
        [EnumDescription("پروانه فعالیت")]
        ActivityLicense = 42,






    }
}
