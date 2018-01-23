using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Enums
{
    public enum GroundTypeEnum
    {
        [EnumDescription("")]
        Null = 0,
        [EnumDescription("مسکونی")]
        Residential = 10,
        [EnumDescription("اداری")]
        Administrative = 20,
        [EnumDescription("اداری - تجاری")]
        AdministrativeCommercial = 30,
        [EnumDescription("پارکینگ طبقاتی")]
        VerticalParking = 40,
        [EnumDescription("تجاری")]
        Commercial = 50,
        [EnumDescription("تفریحی")]
        Recreational = 60,
        [EnumDescription("ورزشی")]
        Sports = 70,
        [EnumDescription("مذهبی")]
        Religious = 80,


    }
}
