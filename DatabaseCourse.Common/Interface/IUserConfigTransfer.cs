using DatabaseCourse.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Interface
{
    public interface IUserConfigTransfer
    {
        List<UserInitItem> GetInitUsers();
    }
}
