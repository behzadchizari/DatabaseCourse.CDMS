using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.Common.Classes
{
    public class DataTransfer
    {
        private IDataTransfer _dto = null;

        public DataTransfer(IDataTransfer dto)
        {
            _dto = dto;
        }

    }
}
