using Microsoft.EntityFrameworkCore;
using Pool.Core.Models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Data.Repositories
{
    public class ActivitiesRepository:IActivitiesRepository
    {
        private readonly DataContext _context;
        public ActivitiesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Activities> GetAll()
        {
            return _context.Activities.Include(u=>u.Instructor);
        }

        public Activities Add(Activities activities)
        {
            _context.Activities.Add(activities);
            _context.SaveChanges();
            return activities;
        }

        public void Delete(int id)
        {
            var activities = GetById(id);
            if (activities != null)
            {
                _context.Activities.Remove(activities);
                _context.SaveChanges();
            }
        }

        public Activities GetById(int id)
        {
            return _context.Activities.Find(id);
        }

        public IEnumerable<Activities> GetList()
        {
            return _context.Activities.Where(s => !string.IsNullOrEmpty(s.Name));
        }


        public Activities Update(int id, Activities activities)
        {
            var existingactivities = GetById(id);
            if (existingactivities != null)
            {
                existingactivities.Name = activities.Name;
                existingactivities.Date = activities.Date;
                existingactivities.Level = activities.Level;
                existingactivities.Level = activities.Level;
                _context.SaveChanges();
            }
            return existingactivities;
        }
    }
}
