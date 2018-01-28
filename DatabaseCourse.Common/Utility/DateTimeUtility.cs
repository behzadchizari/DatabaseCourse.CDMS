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
        public static Dictionary<string, int> GetDateInfoSeperated(string date)
        {
            var arr = date.Split('/');
            var result = new Dictionary<string, int>();
            result["day"] = Convert.ToInt32(arr[2]);
            result["month"] = Convert.ToInt32(arr[1]);
            result["year"] = Convert.ToInt32(arr[0]);

            return result;
        }


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
        public static string ConvertToPersianCalenderGetDate(DateTime? dateTime)
        {
            var pc = new PersianCalendar();
            try
            {
                if (dateTime == null) return "-";
                return $"{pc.GetYear(dateTime ?? DateTime.Now).ToString().PadLeft(4, '0')}/{pc.GetMonth(dateTime ?? DateTime.Now).ToString().PadLeft(2, '0')}/{pc.GetDayOfMonth(dateTime ?? DateTime.Now).ToString().PadLeft(2, '0')}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
