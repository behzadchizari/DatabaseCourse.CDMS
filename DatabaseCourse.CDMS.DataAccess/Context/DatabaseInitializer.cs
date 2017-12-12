using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
using DatabaseCourse.CDMS.DataAccess.Classes;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.DataAccess.Context
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<CDMSEntities>
    {

        private static List<Role> GetRoleFromEnum()
        {
            try
            {
                var enumItem = EnumUtility.List(typeof(UserRoleEnum)).ToList();
                var result = enumItem.Select(item => new Role()
                {
                    Id = item.Value,
                    Title = item.Name,
                    DisplayName = item.Description,

                }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static List<User> GetInitUsers(List<UserInitItem> userInitItem)
        {
            var users = new List<User>();
            foreach (var item in userInitItem)
            {
                users.Add(new User()
                {
                    Username = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Password = item.Password,
                    CreationDate = DateTime.Now,
                    LastModifyDate = DateTime.Now
                });
            }
            return users;
        }

        protected override void Seed(CDMSEntities context)
        {
            #region Default Rols

            IList<Role> defaulRoles = GetRoleFromEnum();
            foreach (var role in defaulRoles)
                context.Role.Add(role);

            #endregion

            #region Default Users

            var userItems = UserConfigTransfer.GetUserInit();
            IList<User> defaulUsers = GetInitUsers(userItems);
            var countId = 0;
            foreach (var user in defaulUsers)
            {
                user.Id = ++countId;
                context.User.Add(user);
                foreach (var userRole in userItems.FirstOrDefault(x => x.UserName == user.Username).RoleList)
                {
                    context.UserRole.Add(new UserRole()
                    {
                        Role_Id = (int)userRole,
                        User_Id = countId
                    });
                }
            }

            #endregion

            base.Seed(context);
        }
    }
}
