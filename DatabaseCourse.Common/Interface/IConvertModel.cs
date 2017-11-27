using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.Common.Interface
{
    public interface IConvertModel<TDataAccessModel, TBusinessModel>
    {
        TDataAccessModel ConvertToDataAccessModel(TBusinessModel businessModel);
        TBusinessModel ConvertToBusinessModel(TDataAccessModel dataAccessModel);
    }
}
