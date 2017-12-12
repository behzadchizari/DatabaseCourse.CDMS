using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Interface;
using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DatabaseCourse.CDMS.WebUi.Classes
{


    public class UserConfigTransfer : IUserConfigTransfer
    {
        public List<UserInitItem> GetInitUsers()
        {
            var result = new List<UserInitItem>();
            try
            {
                var xml = XDocument.Load($@"{ThisApp.BaseDirectory}\Config\UserInit.xml");
                var userTags = xml.Descendants("UserList").Descendants("User");
                foreach (var userTag in userTags)
                {
                    var userRoleTags = userTag.Descendants("RoleList").Descendants("Role");
                    var userRoleResults = userRoleTags.Select(userRoleTag => userRoleTag.Descendants("RoleName").Select(item => item?.Value).FirstOrDefault()).ToList();
                    var roleListResult = new List<UserRoleEnum>();
                    foreach (var userRoleResult in userRoleResults)
                    {
                        roleListResult.Add(EnumUtility.GetEnumByTitle<UserRoleEnum>(userRoleResult));
                    }
                    result.Add(new UserInitItem()
                    {
                        UserName = userTag.Descendants("UserName").Select(item => item?.Value).FirstOrDefault(),
                        Password = userTag.Descendants("Password").Select(item => item?.Value).FirstOrDefault(),
                        FirstName = userTag.Descendants("FirstName").Select(item => item?.Value).FirstOrDefault(),
                        LastName = userTag.Descendants("LastName").Select(item => item?.Value).FirstOrDefault(),
                        RoleList = roleListResult
                    });
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}