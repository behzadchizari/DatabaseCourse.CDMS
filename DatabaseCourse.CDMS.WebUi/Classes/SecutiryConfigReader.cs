using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public class SecutiryConfig
    {
        public enum SecurityType
        {
            Permission = 10
        }

        private static string Url { get; set; }
        private static List<string> RoleGroups { get; set; }




        public static List<SecutiryConfig> GetAllSecurityByType(SecurityType type)
        {
            var result = new List<SecutiryConfig>();
            try
            {
                var baseDir = ThisApp.BaseDirectory;
                var tp = type.ToString();
                XElement xelement = XElement.Load($"{baseDir}Config\\Security.xml");
                //var elements = xelement.Descendants("Security");
                var elements = from sec in xelement.Elements("Security")
                                where (string)sec.Element("SecurityGroup").Attribute("type") == tp
                               select sec;

                foreach (var item in elements)
                {
                    if (true)
                    {
                        result.Add(new SecutiryConfig()
                        {
                        });

                    }
                }
            }
            catch (Exception e)
            {
                result = new List<SecutiryConfig>();

            }
            return result;
        }
    }
}