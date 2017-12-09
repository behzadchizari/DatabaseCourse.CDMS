using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DatabaseCourse.Common.Enums;

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
                var userBll = new UserBLL(null);
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

        #endregion

        #region Methods


        /// <summary>
        /// return value of a key from Web.Config
        /// </summary>
        /// <typeparam name="T">the type you want to return[int|string|double|decimal|bool|float|long|char]</typeparam>
        /// <param name="configName">key name</param>
        /// <returns></returns>
        public static object GetConfiguration<T>(string configName)
        {
            var appConfig = "";
            try
            {
                appConfig = ConfigurationManager.AppSettings[configName];
                return Convert.ChangeType(appConfig, typeof(T));
            }
            catch (Exception)
            {
                return appConfig;
            }
        }

        /// <summary>
        /// return value of a key from Web.Config
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static object GetConfiguration(string configName)
        {
            var appConfig = "";
            try { appConfig = ConfigurationManager.AppSettings[configName]; }
            catch (Exception) { }
            return appConfig;
        }

        #endregion

        #region Helper



        #endregion


    }
}