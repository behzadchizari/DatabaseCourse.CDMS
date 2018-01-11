using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Utility
{
    public class ConfigurationUtility
    {

        /// <summary>
        /// return value of a key from Web.Config
        /// </summary>
        /// <typeparam name="T">the type you want to return[int|string|double|decimal|bool|float|long|char]</typeparam>
        /// <param name="configName">key name</param>
        /// <returns></returns>
        public static object GetConfigurationByKey<T>(string configName, T defaultvalue)
        {
            var appConfig = "";
            try
            {
                appConfig = ConfigurationManager.AppSettings[configName];
                return Convert.ChangeType(appConfig, typeof(T));
            }
            catch (Exception)
            {
                return defaultvalue;
            }
        }
    }
}
