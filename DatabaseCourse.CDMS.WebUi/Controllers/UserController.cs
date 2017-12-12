using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class UserController : BaseController
    {
        #region variables

        public enum EditUserFunctionEnum
        {
            Null = 0,
            Add = 10,
            Update = 20
        }

        #endregion

        #region Action Methods

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserEdit(EditUserFunctionEnum fn, string userName, string password,List<UserRoleEnum> list)
        {
            var result = new JsonResult();
            try
            {

            }
            catch (Exception e)
            {
                
                throw;
            }
            return result;
        }

        #endregion

        #region Abstract Methods


        protected override void SetSessionAndViewBags()
        {
        }

        protected override void LoadSessionAndViewBags()
        {
        }

        protected override Exception InnerSecurityCheck()
        {
            return null;
        }

        #endregion

        #region Helper Methods



        #endregion


    }
}