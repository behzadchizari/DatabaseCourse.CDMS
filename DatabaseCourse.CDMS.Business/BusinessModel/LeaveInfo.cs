using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;

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
            get
            {
                var CooperationDa = new CooperationContractDA();
                return CooperationContractBll.ConvertToBusinessModel(CooperationDa.GetById(CooperationContractId??0));
            }
        }
        
    }
}
