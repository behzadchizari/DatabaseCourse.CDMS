using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Model;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class LeaveInfo
    {
        public int Id { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int? CooperationContractId { get; set; }

        public CooperationContractInfo CooperationContract
        {
            //TODO
            get { return null; }
        }
    }
}
