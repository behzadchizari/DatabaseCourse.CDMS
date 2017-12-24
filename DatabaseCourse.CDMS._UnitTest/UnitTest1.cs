using System;
using System.Linq;
using DatabaseCourse.CDMS.DataAccess.Context;
using DatabaseCourse.CDMS.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCourse.Common.Utility;
using DatabaseCourse.CDMS.DataAccess.DAL;
using System.Collections.Generic;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.Business.BusinessLogic;

namespace DatabaseCourse.CDMS._UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var da = new UserDA();
            da.Add(new User
            {
                LastModifyDate = DateTime.Now,
                CreationDate = DateTime.Now,
                LastModifyUser = null,
                Password = "123",
                Username = "admin",

            }, new List<Common.Enums.UserRoleEnum> { Common.Enums.UserRoleEnum.Admin });


            var rda = new UserDA();
            var b = rda.GetById(1).FirstOrDefault();
            b.Username = "admin22";
            var a = rda.Update(b);


        }

        [TestMethod]
        public void MenuConfigTest()
        {
            var loginfo = new LogExceptionInfo()
            {
                LogType = Common.Enums.LogTypeEnum.Log,
                DateTime = DateTime.Now,
                Message = "behzad",
            };
            var logbll = new LogBLL(null);
            logbll.AddLogException(loginfo);
            var sdc = logbll.GetAllLogAndExceptions();
        }
    }

}
