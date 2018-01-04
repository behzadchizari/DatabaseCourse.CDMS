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
using DatabaseCourse.CDMS.Business.BusinessLogic;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class UserInfo
    {
        #region Private
        private List<UserRoleEnum> _userRoles = null;
        #endregion

        #region Properties

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public int? LastModifyUser { get; set; }

        public UserInfo LastModifyUserData
        {
            get
            {
                if (LastModifyUser == null) return null;
                return UserBLL.ConvertToBusinessModel(new UserDA().GetById(TypeUtility.ConvertToInt(LastModifyUser)).FirstOrDefault());
            }
        }


        public List<UserRoleEnum> UserRoles
        {
            set
            { _userRoles = value; }
            get
            {
                if (_userRoles == null)
                {
                    var EnumList = EnumUtility.List(typeof(UserRoleEnum));
                    var userRoleDa = new UserRoleDA();
                    var userRoles = userRoleDa.GetByUserId(this.Id);
                    var result = new List<UserRoleEnum>();
                    foreach (var item in userRoles) result.Add((UserRoleEnum)item.Role_Id);
                    return result;
                }
                return _userRoles;
            }
        }

        #endregion



    }
}
