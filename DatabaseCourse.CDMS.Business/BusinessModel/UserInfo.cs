using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.Business.Business_Model
{
    public class UserInfo
    {
        #region Properties

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public int? LastModifyUser { get; set; }

        public List<UserRoleEnum> UserRoles { get; set; }

        public List<RoleInfo> Roles { get; set; }

        #endregion



    }
}
