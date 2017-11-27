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

        #region Methods

        public UserInfo GetUserInfoById(int id)
        {
            var da = new UserDA();
            return ConvertToBusinessModel(da.GetById(id).FirstOrDefault());
        }

        public List<UserInfo> GetAllUserInfos()
        {
            var da = new UserDA();
            var userList = da.GetAll();
            var userInfoList = new List<UserInfo>();
            foreach (var user in userList)
            {
                userInfoList.Add(ConvertToBusinessModel(user));
            }
            return userInfoList;
        }

        public UserInfo GetUserInfoByUserNameAndPassword(string username, string password)
        {
            var da = new UserDA();
            var user = da.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
            return ConvertToBusinessModel(user);
        }

        public List<UserInfo> GetUserInfoByRole(UserRoleEnum userRole)
        {

            var da = new UserDA();
            var urda = new UserRoleDA();
            var userRoleVal = EnumUtility.GetEnumValue(userRole);
            var users =
                da.GetAll()
                    .Join(urda.GetAll(), a => a.Id, b => b.User_Id, (a, b) => (b.Role_Id == userRoleVal) ? a : null)
                    .ToList();
            var userInfoList = new List<UserInfo>();
            foreach (var user in users)
            {
                userInfoList.Add(ConvertToBusinessModel(user));
            }
            return userInfoList;
        }

        public Exception AddNewUserInfo(UserInfo user)
        {
            Exception exData = null;
            try
            {
                if(user.UserRoles.Count == 0)
                    return new Exception("Cannot Add New User - Role List is Empty");
                var daModel = ConvertToDataAccessModel(user);
                var da = new UserDA();
                var addedId = da.Add(daModel);
                if (addedId == 0)
                    return new Exception("Cannot Add New User - Internal Error");
                var urda = new UserRoleDA();
                urda.Add(new UserRole()
                {
                    Role_Id = EnumUtility.GetEnumValue(UserRoles[0]),
                    User_Id = addedId
                });
            }
            catch (Exception e)
            {
                exData = new Exception(ExceptionUtility.GetAllInnerException(e));
            }
            return exData;
        }

        #endregion

        #region Helpers
        internal static UserInfo ConvertToBusinessModel(User user)
        {
            if (user != null)
            {
                return new UserInfo()
                {
                    Id = user.Id,
                    LastModifyUser = user.LastModifyUser,
                    Username = user.Username,
                    Password = user.Password,
                    LastModifyDate = user.LastModifyDate,
                    CreationDate = user.CreationDate,
                };
            }
            return null;
        }

        internal static User ConvertToDataAccessModel(UserInfo user)
        {
            if (user != null)
            {
                return new User()
                {
                    Id = user.Id,
                    LastModifyUser = user.LastModifyUser,
                    Username = user.Username,
                    Password = user.Password,
                    LastModifyDate = user.LastModifyDate,
                    CreationDate = user.CreationDate,
                };
            }
            return null;
        }

        #endregion


    }
}
