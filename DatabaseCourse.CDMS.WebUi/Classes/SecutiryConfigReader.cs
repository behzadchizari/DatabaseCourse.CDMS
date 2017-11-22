using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public class SecutiryConfig
    {
        #region Properties

        public string PageName { get; set; }
        public string PageAddress { get; set; }
        public string PageDescription { get; set; }
        public string PageHelp { get; set; }
        public List<string> UserRoles { get; set; }
        public List<UserRoleEnum> UserRoleList
        {
            get
            {
                try
                {
                    var result = new List<UserRoleEnum>();
                    if (UserRoles != null)
                    {
                        foreach (var item in UserRoles)
                        {
                            result.Add(EnumUtility.ConvertStringToEnum(item, UserRoleEnum.Null));
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Retrurn All Pages With UserRoles Wich has Access to Page
        /// </summary>
        /// <returns></returns>
        public static List<SecutiryConfig> GetAllConfig()
        {
            var result = new List<SecutiryConfig>();
            try
            {
                XDocument xml = XDocument.Load($@"{ThisApp.BaseDirectory}\Config\Security.xml");
                var pageTages = xml.Descendants("PageList").Descendants("Page");
                foreach (var pageTag in pageTages)
                {
                    var userRoleResult = new List<string>();
                    var userRoleTags = pageTag.Descendants("UserRoles").Descendants("Role");
                    foreach (var userRoleTag in userRoleTags)
                    {
                        userRoleResult.Add(userRoleTag.Descendants("RoleName").Select(item => item?.Value).FirstOrDefault());
                    }
                    result.Add(new SecutiryConfig()
                    {
                        PageAddress = pageTag.Descendants("PageAddress").Select(item => item?.Value).FirstOrDefault(),
                        PageDescription = pageTag.Descendants("PageDescription").Select(item => item?.Value).FirstOrDefault(),
                        PageHelp = pageTag.Descendants("PageHelp").Select(item => item?.Value).FirstOrDefault(),
                        PageName = pageTag.Descendants("PageName").Select(item => item?.Value).FirstOrDefault(),
                        UserRoles = userRoleResult
                    });
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static SecutiryConfig GetConfigByPageName(string pageAddress)
        {

            var result = new SecutiryConfig();
            try
            {
                var xml = XDocument.Load($@"{ThisApp.BaseDirectory}\Config\Security.xml");
                var pageTag = xml.Descendants("PageList").Descendants("Page").FirstOrDefault(x => x.Descendants("PageAddress").Select(item => item?.Value).FirstOrDefault() == pageAddress);
                var userRoleTags = pageTag?.Descendants("UserRoles")?.Descendants("Role");
                if (userRoleTags != null)
                {
                    var userRoleResult = userRoleTags.Select(userRoleTag => userRoleTag.Descendants("RoleName").Select(item => item?.Value).FirstOrDefault()).ToList();
                    result = new SecutiryConfig()
                    {
                        PageAddress = pageTag.Descendants("PageAddress").Select(item => item?.Value).FirstOrDefault(),
                        PageDescription = pageTag.Descendants("PageDescription").Select(item => item?.Value).FirstOrDefault(),
                        PageHelp = pageTag.Descendants("PageHelp").Select(item => item?.Value).FirstOrDefault(),
                        PageName = pageTag.Descendants("PageName").Select(item => item?.Value).FirstOrDefault(),
                        UserRoles = userRoleResult
                    };
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

    }
}