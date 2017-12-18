using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Enums;
using static DatabaseCourse.CDMS.WebUi.Controllers.UserController;

namespace DatabaseCourse.CDMS.WebUi.Classes.UiModel
{
    public class UserUiModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<UserRoleEnum> UserRoles { get; set; }

        public UserUiModel()
        {
            MakeDefault();
        }

        public List<Exception> ChackModel(EditUserFunctionEnum fn)
        {
            var exData = new List<Exception>();
            var userBll = new UserBLL(ThisApp.CurrentUser);
            var userId = ThisApp.Session["UserId"];
            try
            {
                if (string.IsNullOrEmpty(Username))
                    exData.Add(new Exception("نام کاربری  نمیتواند خالی باشد"));

                var user = userBll.GetUserInfoByUserName(Username);
                if (fn == EditUserFunctionEnum.Add)
                {
                    if (user != null)
                        exData.Add(new Exception("کاربر با این نام کاربری در سیستم وجود دارد"));
                }
                else if(fn == EditUserFunctionEnum.Update)
                {
                    if (Id != 0)
                    {
                        if (user != null)
                        {
                            if (user.Username != Username)
                            {
                                exData.Add(new Exception("کاربر با این نام کاربری در سیستم وجود دارد"));
                            }
                        }
                    }
                }
                if (fn == EditUserFunctionEnum.Add)
                {
                    if (string.IsNullOrEmpty(Password))
                        exData.Add(new Exception("پسوورد نمیتواند خالی باشد"));
                }

                if (UserRoles.Count <= 0)
                    exData.Add(new Exception("هیچ نقشی برای کاربر انتخاب نشده"));

            }
            catch (Exception e)
            {
                exData.Add(e);
            }
            return exData;
        }

        private void MakeDefault()
        {
            Id = 0;
            Username = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
            UserRoles = new List<UserRoleEnum>();
        }
    }
}