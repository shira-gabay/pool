using Pool.Core.Models;
using Pool.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Pool.Data.Repositories
{
    public class SwimmersRepository :ISwimmersRepository
    {
        private readonly DataContext _context;

        public SwimmersRepository(DataContext context)
        {
            _context = context;
        }

        public Swimmers Add(Swimmers swimmers)
        {
            _context.Swimmers.Add(swimmers);
            _context.SaveChanges();
            return swimmers;
        }

        public void Delete(int id)
        {
            var swimmer = GetById(id);
            if (swimmer != null)
            {
                _context.Swimmers.Remove(swimmer);
                _context.SaveChanges();
            }
        }

        public Swimmers GetById(int id)
        {
            return _context.Swimmers.Find(id);
        }

        public IEnumerable<Swimmers> GetList()
        {
            return _context.Swimmers.Where(s => !string.IsNullOrEmpty(s.Name));
        }


        public Swimmers Update(int id, Swimmers swimmers)
        {
            var existingSwimmer = GetById(id);
            if (existingSwimmer != null)
            {
                existingSwimmer.Name = swimmers.Name;
                existingSwimmer.Email = swimmers.Email;
                existingSwimmer.Level = swimmers.Level;
                existingSwimmer.Phone = swimmers.Phone;
                _context.SaveChanges();
            }
            return existingSwimmer;
        }
    }
}
