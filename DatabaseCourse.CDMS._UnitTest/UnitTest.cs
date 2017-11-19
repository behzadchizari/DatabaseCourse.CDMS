using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCourse.CDMS.WebUi.Classes;

namespace DatabaseCourse.CDMS._UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var test = ThisApp.GetConfiguration("test");
            var tp = test.GetType();
            SecutiryConfig.GetAllSecurityByType(SecutiryConfig.SecurityType.Permission);
        }
    }
}
