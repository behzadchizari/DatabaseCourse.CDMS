using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public class MenuConfig
    {
        #region properties

        public string MenuId { get; set; }
        public string MenuTitle { get; set; }
        public string MenuDescription { get; set; }
        public string MenuUrl { get; set; }
        public string MenuIcon { get; set; }
        public List<UserRoleEnum> RoleList { get; set; }
        public List<MenuConfig> ChildMenuList { get; set; } = new List<MenuConfig>();
        public string ParentId { get; set; }

        #endregion

        #region Methods

        private static List<MenuConfig> ReadConfigFile()
        {
            var allConfig = new List<MenuConfig>();
            var result = new List<MenuConfig>();
            try
            {
                var xml = XDocument.Load($@"{ThisApp.BaseDirectory}\Config\Menu.xml");
                var MenuTags = xml.Descendants("MenuItemList").Descendants("Menu");

                allConfig.AddRange(from item in MenuTags
                                   let userRoleTags = item?.Descendants("RoleList")?.Descendants("Role")
                                   let userRoleResult = userRoleTags?.Select(userRoleTag => userRoleTag.Descendants("RoleName").Select(x => x?.Value).FirstOrDefault()).ToList()
                                   let userRoleEnumList = userRoleResult?.Select(EnumUtility.GetEnumByTitle<UserRoleEnum>).ToList()
                                   where item != null
                                   select new MenuConfig()
                                   {
                                       MenuId = item.Descendants("MenuId").Select(x => x?.Value).FirstOrDefault(),
                                       MenuDescription = item.Descendants("MenuDescription").Select(x => x?.Value).FirstOrDefault(),
                                       MenuIcon = item.Descendants("MenuIcon").Select(x => x?.Value).FirstOrDefault(),
                                       MenuTitle = item.Descendants("MenuTitle").Select(x => x?.Value).FirstOrDefault(),
                                       MenuUrl = item.Descendants("MenuUrl").Select(x => x?.Value).FirstOrDefault(),
                                       RoleList = userRoleEnumList,
                                       ParentId = item.Descendants("ParentId").Select(x => x?.Value).FirstOrDefault(),
                                   });


                foreach (var item in allConfig)
                {
                    if (string.IsNullOrEmpty(item.ParentId)) continue;
                    var parent = allConfig.FirstOrDefault(x => x.MenuId == item.ParentId);
                    parent?.ChildMenuList.Add(item);
                }

                result.AddRange(allConfig.Where(item => string.IsNullOrEmpty(item.ParentId)));
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public static List<MenuConfig> GetMenuByUserRoles(List<UserRoleEnum> userRoles)
        {
            var result = new List<MenuConfig>();
            var menuList = ReadConfigFile();
            try
            {
                foreach (var item in menuList)
                {
                    if (item.RoleList.Any(x => x == UserRoleEnum.All))
                    {
                        result.Add(item);
                        continue;
                    }
                    result.AddRange(from role in userRoles where item.RoleList.Any(x => x == role) select item);
                }
                return result.Distinct().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}