using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Utility
{
    public class ExceptionUtility
    {
        public static string GetAllInnerException(Exception exception)
        {
            var message = exception.Message;
            var innerEx = exception.InnerException;
            while (innerEx != null)
            {
                message += $" - {innerEx.Message}";
                innerEx = innerEx.InnerException;
            }
            return message;
        }
    }
}
