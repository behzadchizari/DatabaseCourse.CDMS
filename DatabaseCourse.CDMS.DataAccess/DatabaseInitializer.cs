using DatabaseCourse.CDMS.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.Common.Utility.EnumUtility;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.DataAccess
{
    internal class DatabaseInitializer : DropCreateDatabaseAlways<CDMSEntities>
    {

        private static List<Role> GetRoleFromEnum()
        {
            try
            {
                var enumItem = EnumUtility.List(typeof(UserRoleEnum)).ToList();
                var result = enumItem.Select(item => new Role()
                {
                    Id = item.Value,
                    Title = item.Name,
                    DisplayName = item.Description,

                }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override void Seed(CDMSEntities context)
        {
            #region Default Rols

            IList<Role> defaulRoles = GetRoleFromEnum();
            foreach (var role in defaulRoles)
                context.Role.Add(role);

            #endregion


            base.Seed(context);
        }
    }
}
