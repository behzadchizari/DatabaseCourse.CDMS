using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class ProjectInfo
    {
        private UserInfo _user = null;


        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string GroundType { get; set; }
        public string ProductionLicense { get; set; }
        public DateTime? EndingDate { get; set; }
        public int? UserId { get; set; }
        public int? SupervisorEngineerId { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string GroundOwner { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public SupervisorEngineer SupervisorEngineer
        {
            get
            {
                //TODO
                return null;
            }
        }

        public UserInfo User
        {
            set { _user = value; }
            get
            {
                if (_user != null) return _user;
                if (UserId == null) return null;
                return UserBll.ConvertToBusinessModel(new UserDA().GetById(UserId ?? 0).FirstOrDefault());
            }
        }
    }
}
