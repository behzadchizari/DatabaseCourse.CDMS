using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.WebUi.Classes.UiModel
{
    public class UserUiModel
    {
        public string Username { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Password { get; set; }
        public List<UserRoleEnum> UserRoles { get; set; }

        public List<Exception> ChackModel()
        {
            var exData = new List<Exception>();
            var userBll = new UserBLL(ThisApp.CurrentUser);
            try
            {
                if (string.IsNullOrEmpty(Username))
                    exData.Add(new Exception("نام کاربری  نمیتواند خالی باشد"));
                var user = userBll.GetUserInfoByUserName(Username);
                if (user != null)
                    exData.Add(new Exception("کاربر با این نام کاربری در سیستم وجود دارد"));

                if (string.IsNullOrEmpty(Password))
                    exData.Add(new Exception("پسوورد نمیتواند خالی باشد"));

                if (UserRoles.Count <= 0)
                    exData.Add(new Exception("هیچ نقشی برای کاربر انتخاب نشده"));

            }
            catch (Exception e)
            {
                exData.Add(e);
            }
            return exData;
        }
    }
}