using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class AttachmentDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Attachment entity)
        {
            entity.CreationDate = DateTime.Now;
            _context?.Attachment?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(Attachment entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Attachment?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }
        public int Delete(int entityId)
        {
            if (entityId == 0) return 0;
            var entity = _context?.Attachment?.FirstOrDefault(x => x.Id == entityId);
            if (entity == null) return 0;
            _context?.Attachment?.Remove(entity);
            _context?.SaveChanges();
            return entityId;
        }

        public IQueryable<Attachment> GetAll()
        {
            return _context?.Attachment?.AsQueryable();
        }

        public Attachment GetById(int id)
        {
            return _context?.Attachment?.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Attachment> GetAttachmentByProjectIdAndAttachmentCategoryAndAttachmentType(
            int projectId, 
            string attachmentCategory = null ,
            string attachmentType = null)
        {
            if (attachmentCategory != null && attachmentType != null)
                return _context?.Attachment?.Where(x => x.ProjectId == projectId &&
                x.AttachmentCategory == attachmentCategory &&
                x.AttachmentType == attachmentType);

           if(attachmentCategory != null )
                return _context?.Attachment?.Where(x => x.ProjectId == projectId &&
               x.AttachmentCategory == attachmentCategory);

            else
                return _context?.Attachment?.Where(x => x.ProjectId == projectId);
        }

        public int Update(Attachment entity)
        {
            var newEntity = _context?.Attachment?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating User. User not Found");
            newEntity.AttachmentType = entity?.AttachmentType ?? newEntity.AttachmentType;
            newEntity.FileAddress = entity?.FileAddress ?? newEntity.FileAddress;
            newEntity.AttachmentCategory = entity?.AttachmentCategory ?? newEntity.AttachmentCategory;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;

        }
    }
}
