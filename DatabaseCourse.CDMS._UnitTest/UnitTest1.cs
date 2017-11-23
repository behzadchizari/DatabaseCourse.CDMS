using System;
using System.Linq;
using DatabaseCourse.CDMS.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseCourse.CDMS._UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CDMSEntities ent = new CDMSEntities();
            var d = ent.Role.ToList();
        }
    }
}
