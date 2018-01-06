using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility;
using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class UserBll
    {
        #region Properties

        private readonly CurrentUser _currentUser = null;

        #endregion

        #region ctor
        public UserBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
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
        public UserInfo GetUserInfoByUserName(string username)
        {
            var da = new UserDA();
            var user = da.GetAll().FirstOrDefault(x => x.Username == username);
            return ConvertToBusinessModel(user);
        }
        public UserInfo GetUserInfoByUserNameAndPassword(string username, string password)
        {
            var da = new UserDA();
            var encPass = password;
            var user = da.GetAll().FirstOrDefault(x => x.Username == username && x.Password == encPass);
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
                user.CreationDate = DateTime.Now;
                user.LastModifyDate = DateTime.Now;
                user.LastModifyUser = _currentUser?.Id;
                if (user.UserRoles.Count == 0)
                    return new Exception("Cannot Add New User - No Rule is Selected.");
                var daModel = ConvertToDataAccessModel(user);
                var da = new UserDA();
                var addedId = da.Add(daModel, user.UserRoles);
                if (addedId == 0)
                    return new Exception("Cannot Add New User - Internal Error.");
            }
            catch (Exception e)
            {
                exData = new Exception(ExceptionUtility.GetAllInnerException(e));
            }
            return exData;
        }
        public Exception UpdateExistingUserInfor(UserInfo user)
        {
            Exception exData = null;
            try
            {
                user.LastModifyDate = DateTime.Now;
                user.LastModifyUser = _currentUser?.Id;
                var da = new UserDA();
                var roleDA = new UserRoleDA();
                var roles = roleDA.GetByUserId(user.Id).ToList();
                foreach (var userRole in user.UserRoles)
                {
                    if (roles.Any(x => x.Role_Id == (int)userRole)) continue;
                    roleDA.Add(new UserRole()
                    {
                        Role_Id = (int)userRole,
                        User_Id = user.Id
                    });
                }
                foreach (var role in roles)
                {
                    if (user.UserRoles.Any(x => (int)x == role.Role_Id)) continue;
                    roleDA.Delete(role);
                }
                var update = da.Update(UserBll.ConvertToDataAccessModel(user));
                if (update == 0)
                    return new Exception("Cannot Add New User - Internal Error.");
            }
            catch (Exception ex)
            {
                exData = new Exception(ExceptionUtility.GetAllInnerException(ex));
            }
            return exData;
        }
        public Exception RemoveUser(UserInfo user)
        {
            var da = new UserDA();
            try
            {
                if (user == null)
                    return new Exception("User not Found.");
                var deletedId = da.Delete(ConvertToDataAccessModel(user));
                if (deletedId <= 0)
                    return new Exception("Cannot Delete User. Internal Error");
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
        public Exception RemoveUser(int id)
        {
            var da = new UserDA();
            try
            {
                var user = da.GetById(id).FirstOrDefault();
                if (user == null)
                    return new Exception("User not Found.");
                var deletedId = da.Delete(user);
                if (deletedId <= 0)
                    return new Exception("Cannot Delete User. Internal Error");
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
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
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
