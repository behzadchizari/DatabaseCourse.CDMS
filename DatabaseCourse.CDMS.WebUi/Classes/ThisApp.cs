using DatabaseCourse.Common.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public static class ThisApp
    {
        public static string PageTitle { get; set; }

        public static Exception AccessDenied { get; set; }

        public  static CurrentUser CurrentUser{ get; set; }

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
            try{appConfig = ConfigurationManager.AppSettings[configName];}
            catch (Exception){}
            return appConfig;
        }
    }
}