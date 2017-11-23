using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.CDMS.DataAccess.Model;
using System.Linq;

namespace DatabaseCourse.CDMS._UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var ent = new CDMSEntities();
            var id = ent.UserRole.ToList();
            var test = ThisApp.GetConfiguration("test");
            var tp = test.GetType();
            SecutiryConfig.GetAllSecurityByType(SecutiryConfig.SecurityType.Permission);
        }
    }
}
