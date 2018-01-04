﻿using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class ProjectDA 
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Project entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.LastModifiedDate = DateTime.Now;
            _context?.Project?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(Project entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Project?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<Project> GetAll()
        {
            return _context?.Project?.AsQueryable();
        }

        public IQueryable<Project> GetById(int id)
        {
            return _context?.Project?.Where(x => x.Id == id);
        }

        public int Update(Project entity)
        {
            var newEntity = _context?.Project?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating Contractor. Contractor not Found");
            newEntity.EndingDate = entity?.EndingDate ?? newEntity.EndingDate;
            newEntity.GroundType = entity?.GroundType?? newEntity.GroundType;
            newEntity.LastModifiedDate = DateTime.Now;
            newEntity.ProductionLicense = entity?.ProductionLicense ?? newEntity.ProductionLicense;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}