using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.Business.BusinessLogic;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class CooperationContractInfo
    {
        private ProjectBll _projectBll = new ProjectBll();
        private ContractorBll _contractorBll = new ContractorBll();

        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string WageType { get; set; }

        public int? ContractorId { get; set; }

        public int? ProjectId { get; set; }

        public ProjectInfo Project
        {
            get
            {
                if (ProjectId != 0 && ProjectId != null)
                {
                    return _projectBll.GetByProjectId(ProjectId ?? 0);
                }
                else
                {
                    return null;
                }
            }
        }

        public ContractorInfo Contractor
        {
            get
            {
                if (ContractorId != 0 && ContractorId != null)
                {
                    return _contractorBll.GetContractorById(ContractorId ?? 0);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
