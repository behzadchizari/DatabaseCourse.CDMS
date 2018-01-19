using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class InspectionBll
    {
        #region Variables

        private CurrentUser _currentUser = null;

        #endregion

        #region Ctor

        public InspectionBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods


        #endregion

        #region Helper
        internal Inspection ConvertToDataAccessModel(InspectionInfo businessModel)
        {
            if (businessModel == null) return null;
            return new Inspection()
            {
                Id = businessModel.Id,
                ProjectId = businessModel.ProjectId,
                Date = businessModel.Date,
                Result = businessModel.Result
            };
        }

        internal InspectionInfo ConvertToBusinessModel(Inspection dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new InspectionInfo()
            {
                Id = dataAccessModel.Id,
                ProjectId = dataAccessModel.ProjectId,
                Date = dataAccessModel.Date,
                Result = dataAccessModel.Result
            };
        }
        #endregion
    }
}
