using System;
using System.Linq;
using DatabaseCourse.CDMS.DataAccess.Context;
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
            var snvlsk = new Derived();
        }
    }

    public class Derived : Base<int>
    {
        
    }

    public class Base<TK,TU>
    {
        public Base()
        {
            type = this.GetType();
        }

        public Type type { get; set; }


        public T Get(object obj)
        {
            var ob= this.GetType().c;
        }
    }
}
