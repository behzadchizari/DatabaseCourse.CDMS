using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.Business.Business_Model
{
    public class UserRoleInfo
    {
        #region Properties
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? RoleId { get; set; }

        public int UserIdInt => Convert.ToInt32(UserId?.ToString() ?? "0");

        public int RoleIdInt => Convert.ToInt32(RoleId?.ToString() ?? "0");

        public virtual RoleInfo Role
        {
            get
            {
                var roleDa = new RoleDA();
                if (RoleId == null) return null;
                var roleInfo = roleDa.GetById(RoleIdInt).FirstOrDefault();
                return RoleInfo.ConvertToBusinessModel(roleInfo);
            }
        }

        public virtual UserInfo User{
            get
            {
                var userDa = new UserDA();
                if (RoleId == null) return null;
                var userInfo = userDa.GetById(RoleIdInt).FirstOrDefault();
                return UserInfo.ConvertToBusinessModel(userInfo);
            }
        }
        #endregion

        #region Business Methods
        

        #endregion

        #region Helpers

        internal static UserRole ConvertToDataAccessModel(UserRoleInfo userRoleInfo)
        {
            if (userRoleInfo != null)
            {
                return new UserRole()
                {
                    Id = userRoleInfo.Id,
                    Role_Id = userRoleInfo.RoleId,
                    User_Id = userRoleInfo.UserId
                };
            }
            return null;
        }

        internal static UserRoleInfo ConvertToBusinessModel(UserRole userRole)
        {
            if (userRole != null)
            {
                return new UserRoleInfo()
                {
                    Id = userRole.Id,
                    RoleId = userRole.Role_Id,
                    UserId = userRole.User_Id
                };
            }
            return null;
        }

        #endregion



    }
}
