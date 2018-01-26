using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public class ContractorUiModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string InsuranceNo { get; set; }
        public string Contact { get; set; }
    }
}