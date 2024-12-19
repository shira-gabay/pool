using Pool.Core.Models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class InstructorsRepository:IInstructorsRepository
    {
        private readonly DataContext _context;
        public InstructorsRepository(DataContext context)
        {
            _context = context;
        }
        public Instructors Add(Instructors instructors)
        {
            _context.Instructors.Add(instructors);
            _context.SaveChanges();
            return instructors;
        }

        public void Delete(int id)
        {
            var instructors = GetById(id);
            if (instructors != null)
            {
                _context.Instructors.Remove(instructors);
                _context.SaveChanges();
            }
        }

        public Instructors GetById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public IEnumerable<Instructors> GetList()
        {
            return _context.Instructors.Where(s => !string.IsNullOrEmpty(s.Name));
        }


        public Instructors Update(int id, Instructors swimmers)
        {
            var existingInstructors = GetById(id);
            if (existingInstructors != null)
            {
                existingInstructors.Name = swimmers.Name;
                existingInstructors.Specialty = swimmers.Specialty;
                existingInstructors.Experience = swimmers.Experience;
                existingInstructors.Phone = swimmers.Phone;
                _context.SaveChanges();
            }
            return existingInstructors;
        }
    }

   
}
