using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCourse.CDMS.WebUi.Classes;
using System.Collections;
using System.Linq;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS._UnitTest
{
    public enum Test
    {
        Null,
        NotNull=10,
    }
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {

            var xml = SecutiryConfig.GetAllConfig();
            var xml2 = SecutiryConfig.GetConfigByPageName("/Default/Index2");
            var enumutil = EnumUtility.GetEnumValue(Test.NotNull);

            var snu = EnumUtility.ConvertStringToEnum("CfEO",UserRoleEnum.Null);
            var colenm = EnumUtility.List(typeof(UserRoleEnum)).ToList();
            

            var test = ThisApp.GetConfiguration("test");
            var tp = test.GetType();
            //SecutiryConfig.GetAllSecurityByType(SecutiryConfig.SecurityType.Permission);
        }
    }
}
