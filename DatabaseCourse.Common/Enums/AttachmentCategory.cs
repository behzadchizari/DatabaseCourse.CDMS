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
        [EnumDescription("نقشه")]
        Map = 10,
        [EnumDescription("قرارداد")]
        Contract = 20,
        
    }
}
