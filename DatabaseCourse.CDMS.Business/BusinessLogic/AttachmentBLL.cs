using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.DataAccess.DAL;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Interface;
using DatabaseCourse.Common.Utility.EnumUtility;
using System.Collections.Generic;

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

        public int AddNewAttachment(AttachmentInfo attachment)
        {
            return _attachmentDa.Add(ConvertToDataAccessModel(attachment));
        }

        public int UpdateExsitingAttachmetn(AttachmentInfo attachment)
        {
            return _attachmentDa.Update(ConvertToDataAccessModel(attachment));
        }

        public int RemoveAttachmentById(int id)
        {
            var attachment = _attachmentDa.GetById(id);
            return _attachmentDa.Delete(attachment);
        }

        public List<AttachmentInfo> GetByProjectIdAndType(int projectId, AttachmentCategoryEnum cat, AttachmentTypeEnum type)
        {
            var list = _attachmentDa.GetAttachmentByProjectIdAndAttachmentCategoryAndAttachmentType(projectId,
                                                        type == AttachmentTypeEnum.Null ? null : cat.ToString(),
                                                        cat == AttachmentCategoryEnum.Null ? null : type.ToString());

            var result = new List<AttachmentInfo>();
            foreach (var item in list)
            {
                result.Add(ConvertToBusinessModel(item));
            }

            return result;
        }
        #endregion

        #region Helper
        internal Attachment ConvertToDataAccessModel(AttachmentInfo businessModel)
        {
            if (businessModel == null) return null;
            return new Attachment()
            {
                Id = businessModel.Id,
                AttachmentCategory = businessModel.AttachmentCategory.ToString(),
                AttachmentType = businessModel.AttachmentType.ToString(),
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
                AttachmentCategory = EnumUtility.GetEnumByTitle<AttachmentCategoryEnum>(dataAccessModel.AttachmentCategory),
                AttachmentType = EnumUtility.GetEnumByTitle<AttachmentTypeEnum>(dataAccessModel.AttachmentType),
                CreationDate = dataAccessModel.CreationDate,
                FileAddress = dataAccessModel.FileAddress,
                ProjectId = dataAccessModel.ProjectId
            };
        }
        #endregion

    }
}
