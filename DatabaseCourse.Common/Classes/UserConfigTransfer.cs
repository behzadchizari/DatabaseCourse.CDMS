using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.Classes
{
    public class UserConfigTransfer
    {
        private static IUserConfigTransfer _iUserConfigTransfer = null;
        public UserConfigTransfer(IUserConfigTransfer iUserConfigTransfer)
        {
            _iUserConfigTransfer = iUserConfigTransfer;
        }

        public static List<UserInitItem> GetUserInit()
        {
            if (_iUserConfigTransfer != null)
                return _iUserConfigTransfer.GetInitUsers();
            return null;
        }
    }
}
