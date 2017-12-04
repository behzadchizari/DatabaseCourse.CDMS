using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult PressLogin(string userName,string password)
        {
            var json = new JsonResult();
            try
            {
                var userBll = new UserBLL(ThisApp.CurrentUser);
                var user = userBll.GetUserInfoByUserNameAndPassword(userName, password);
                if (user == null)
                {
                    json.Data = new
                    {
                        Status = ""
                    };
                }
                else
                {
                }
            }
            catch (Exception)
            {

                throw;
            }
            return json;
        }
    }
}