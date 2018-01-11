using DatabaseCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.Business.BusinessModel
{
    public class AttachmentInfo
    {

        public int Id { get; set; }

        public string FileAddress { get; set; }

        public AttachmentCategoryEnum AttachmentCategory { get; set; }

        public AttachmentTypeEnum AttachmentType { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? ProjectId { get; set; }

        public ProjectInfo Project
        {
            //TODO
            get { return null; }
        }
    }
}
