using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Utility
{
    public class DateTimeUtility
    {
        public static string ConvertToPersianCalender(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            try
            {
                return
                    $"{pc.GetHour(dateTime).ToString().PadLeft(2, '0')}:{pc.GetMinute(dateTime).ToString().PadLeft(2, '0')}:{pc.GetSecond(dateTime).ToString().PadLeft(2, '0')} " +
                    $"{pc.GetYear(dateTime).ToString().PadLeft(4, '0')}/{pc.GetMonth(dateTime).ToString().PadLeft(2, '0')}/{pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0')}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static string ConvertToPersianCalenderGetDate(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            try
            {
                return $"{pc.GetYear(dateTime).ToString().PadLeft(4, '0')}/{pc.GetMonth(dateTime).ToString().PadLeft(2, '0')}/{pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0')}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
