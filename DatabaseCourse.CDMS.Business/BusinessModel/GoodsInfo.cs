using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class GoodsInfo
    {
        //TODO
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        public string Module { get; set; }

        public string Description { get; set; }
        
    }
}
