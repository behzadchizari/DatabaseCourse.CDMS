﻿using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.Business.BusinessLogic
{
    public class AttachmentBll
    {
        #region Variables

        private CurrentUser _currentUser = null;
        private AttachmentDA _attachmentDa = new AttachmentDA();

        #endregion

        #region Ctor

        public AttachmentBll(CurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        #endregion

        #region Methods

        //public int AddNewAttachment()
        //{
            
        //}

        #endregion

        #region Helper
        internal Attachment ConvertToDataAccessModel(AttachmentInfo businessModel)
        {
            if (businessModel == null) return null;
            return new Attachment()
            {
                Id = businessModel.Id,
                AttachmentCategory = businessModel.AttachmentCategory,
                AttachmentType = businessModel.AttachmentType,
                CreationDate = businessModel.CreationDate,
                FileAddress = businessModel.FileAddress,
                ProjectId = businessModel.ProjectId
            };
        }

        internal AttachmentInfo ConvertToBusinessModel(Attachment dataAccessModel)
        {
            if (dataAccessModel == null) return null;
            return new AttachmentInfo()
            {
                Id = dataAccessModel.Id,
                AttachmentCategory = dataAccessModel.AttachmentCategory,
                AttachmentType = dataAccessModel.AttachmentType,
                CreationDate = dataAccessModel.CreationDate,
                FileAddress = dataAccessModel.FileAddress,
                ProjectId = dataAccessModel.ProjectId
            };
        }
        #endregion

    }
}
