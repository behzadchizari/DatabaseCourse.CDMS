using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class RoleInfo
    {
        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string DisplayName { get; set; }

        public UserRoleEnum RoleEnum => EnumUtility.GetEnumByTitle<UserRoleEnum>(Title);

        #endregion

        #region Business Methods



        #endregion

        #region Helpers


        internal static RoleInfo ConvertToBusinessModel(Role role)
        {
            if (role != null)
            {
                return new RoleInfo()
                {
                    Id = role.Id,
                    DisplayName = role.DisplayName,
                    Title = role.Title
                };
            }
            return null;
        }

        internal static Role ConvertToDataAccessModel(RoleInfo role)
        {
            if (role != null)
            {
                return new Role()
                {
                    Id = role.Id,
                    DisplayName = role.DisplayName,
                    Title = role.Title
                };
            }
            return null;
        }

        #endregion


    }
}
