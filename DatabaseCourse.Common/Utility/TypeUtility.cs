using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Utility
{
    public class TypeUtility
    {
        /// <summary>
        /// Convert nullable Integer To Integer 
        /// </summary>
        /// <param name="number"></param>
        /// <returns>returns 0 if number is null`</returns>
        public static int ConvertToInt(int? number)
        {
            try
            {
                if (number == null) return 0;
                return Convert.ToInt32(number.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert Integer To Nullable Integer
        /// </summary>
        /// <param name="number">Nullable Integer</param>
        /// <returns></returns>
        public static int? ConvertToNullableInt(int number)
        {
            try
            {

            return Convert.ToUInt16(number.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
