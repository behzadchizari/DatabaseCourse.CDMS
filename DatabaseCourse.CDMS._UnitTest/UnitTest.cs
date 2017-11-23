using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCourse.CDMS.WebUi.Classes;
<<<<<<< HEAD
using System.Collections;
using System.Linq;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
=======
using DatabaseCourse.CDMS.DataAccess.Model;
using System.Linq;
>>>>>>> origin/master

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
<<<<<<< HEAD

            var xml = SecutiryConfig.GetAllConfig();
            var xml2 = SecutiryConfig.GetConfigByPageName("/Default/Index2");
            var enumutil = EnumUtility.GetEnumValue(Test.NotNull);

            var snu = EnumUtility.ConvertStringToEnum("CfEO",UserRoleEnum.Null);
            var colenm = EnumUtility.List(typeof(UserRoleEnum)).ToList();
            

=======
            var ent = new CDMSEntities();
            var id = ent.UserRole.ToList();
>>>>>>> origin/master
            var test = ThisApp.GetConfiguration("test");
            var tp = test.GetType();
            //SecutiryConfig.GetAllSecurityByType(SecutiryConfig.SecurityType.Permission);
        }
    }
}
