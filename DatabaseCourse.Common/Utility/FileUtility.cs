using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Utility
{
    public class FileUtility
    {
        private string _fileInitName;
        public FileUtility(string fileInitName)
        {
            this._fileInitName = fileInitName;
        }

        public string FileName
        {
            get
            {
                try
                {
                    var arr = _fileInitName.Split('.');
                    var name = arr.ToList().Where(item => item != arr.Last()).Aggregate("", (current, item) => current + item).Split('\\').Last();
                    return name;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public string FileExtention
        {
            get
            {
                try
                {
                    var arr = _fileInitName.Split('.');
                    return arr.Last();
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public bool IsExtentionAcception
        {
            get
            {
                try
                {
                    var accExt = new List<string>(){ "PDF", "PNG", "JPG", "JPEG", "DOCX", "DOC", "XLS", "XLSX" };
                    return accExt.Any(x=>x== FileExtention.ToUpper());
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
