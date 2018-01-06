using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class ContractorInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalId { get; set; }

        public string InsuranceNo { get; set; }

        public DateTime? FirstCooperationDate { get; set; }

        public string Contact { get; set; }

    }
}
