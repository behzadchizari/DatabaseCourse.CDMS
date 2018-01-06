using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class CooperationContractInfo
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string WageType { get; set; }

        public int? ContractorId { get; set; }

        public int? ProjectId { get; set; }

        public ProjectInfo Project
        {
            //TODO
            get { return null; }
        }

    }
}
