using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class InspectionInfo
    {

        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Result { get; set; }

        public int? ProjectId { get; set; }

        public ProjectInfo Project { get; set; }

        public SupervisorEngineerInfo SupervisorEngineer
        {
            //TODO
            get { return null; }
        }
    }
}
