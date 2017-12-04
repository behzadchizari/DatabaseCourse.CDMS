using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.Common.Classes
{
    public class CurrentUser
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public int? LastModifyUser { get; set; }

        public List<UserRoleEnum> UserRoles{ get; set; }
    }
}
