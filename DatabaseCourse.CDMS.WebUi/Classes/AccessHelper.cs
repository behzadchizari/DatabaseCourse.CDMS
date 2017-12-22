using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public class AccessHelper
    {
        public static Exception HasAccessToAction(string controllerName, string actionName, UserInfo user = null,bool setPageSetting = false)
        {

            var userbll = new UserBLL(ThisApp.CurrentUser);
            if (user == null && ThisApp.CurrentUser != null)
                user = userbll.GetUserInfoById(ThisApp.CurrentUser.Id);

            var security = SecutiryConfig.GetConfigByPageName($@"/{controllerName}/{actionName}");
            if (security != null)
            {
                if (setPageSetting)
                {
                    ThisApp.PageTitle = null;
                    ThisApp.PageDesctiption = null;
                    ThisApp.PageTitle = security.PageName;
                    ThisApp.PageDesctiption = security.PageDescription;
                }

                if (user != null && controllerName == "Login" && actionName == "Index")
                {
                    ThisApp.AccessDeniedType = AccessDeniedType.UserLogined;
                    return new Exception(EnumUtility.GetEnumDescription(AccessDeniedType.UserLogined));
                }
                //check user from this app 
                foreach (var userRole in security.UserRoleList)
                {
                    //check role of user with page permission   
                    if ((ThisApp.CurrentUser == null && userRole == UserRoleEnum.Guest))
                    {
                        ThisApp.AccessDeniedType = AccessDeniedType.Null;
                        return null;
                    }
                    if (user != null && userRole == UserRoleEnum.All)
                    {
                        ThisApp.AccessDeniedType = AccessDeniedType.Null;
                        return null;
                    }
                    if (user == null)
                    {
                        ThisApp.AccessDeniedType = AccessDeniedType.NotLogined;
                        return new Exception(EnumUtility.GetEnumDescription(AccessDeniedType.NotLogined));
                    }
                    if (!user.UserRoles.Any(x => x == userRole || x == UserRoleEnum.SuperAdmin)) continue;
                    ThisApp.AccessDeniedType = AccessDeniedType.Null;
                    return null;
                }
            }
            else
            {
                ThisApp.AccessDeniedType = AccessDeniedType.NoSecurityConfig;
                return new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.", new Exception("مورد امنیتی برای صفحه‌ی مورد نظر یافت نشد.")); ;
            }
            ThisApp.AccessDeniedType = AccessDeniedType.NoAccessToPage;
            return new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.");
        }
    }
}