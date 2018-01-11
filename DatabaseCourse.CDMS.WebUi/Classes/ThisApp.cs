using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.Business.Classes;
using DatabaseCourse.Common.Utility;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public static class ThisApp
    {
        #region Variables

        #endregion

        #region Properties

        public static string PageTitle { get; set; }
        public static string PageDesctiption { get; set; }
        public static Exception AccessDenied { get; set; }
        public static Exception InnerAccessDenied { get; set; }
        public static AccessDeniedType AccessDeniedType { get; set; }
        public static CurrentUser CurrentUser
        {
            get
            {
                var sessionUserId = HttpContext.Current.Session["UserId"];
                if (sessionUserId == null) return null;
                int userId = 0;
                if (!int.TryParse(sessionUserId.ToString(), out userId)) return null;
                var userBll = new UserBll(null);
                var user = userBll.GetUserInfoById(userId);
                if (user == null) return null;
                return new CurrentUser()
                {
                    Id = user.Id,
                    CreationDate = user.CreationDate,
                    LastModifyDate = user.LastModifyDate,
                    LastModifyUser = user.LastModifyUser,
                    UserRoles = user.UserRoles,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
        }
        public static string BaseDirectory
        {
            get
            {
                try
                {
                    return AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", "");
                }
                catch (Exception)
                {
                    return "";
                }

            }
        }
        public static List<MenuConfig> MenuItems
        {
            get
            {
                try
                {
                    if (CurrentUser != null)
                    {
                        if (CurrentUser.UserRoles == null) return null;
                        return MenuConfig.GetMenuByUserRoles(CurrentUser.UserRoles);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static Dictionary<string, object> Session { get; set; } = new Dictionary<string, object>();
        #endregion

        #region Methods


        /// <summary>
        /// return value of a key from Web.Config
        /// </summary>
        /// <typeparam name="T">the type you want to return[int|string|double|decimal|bool|float|long|char]</typeparam>
        /// <param name="configName">key name</param>
        /// <returns></returns>
        public static object GetConfiguration<T>(string configName,T defaultValue)
        {
            return ConfigurationUtility.GetConfigurationByKey<T>(configName, defaultValue);
        }
        
        public static bool HasAccessToView(string controllerName, string acctionName, UserInfo user = null)
        {
            try
            {
                var acc = AccessHelper.HasAccessToAction(controllerName, acctionName, user);
                return acc == null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void AddLogData(string message)
        {
            LogException.AddLogData(message, ThisApp.CurrentUser);
        }
        public static void AddExceptionData(Exception exception)
        {
            LogException.AddExceptionData(exception, ThisApp.CurrentUser);
        }

        #endregion

        #region Helper



        #endregion


    }
}