using Pool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Repositories
{
    public interface IInstructorsRepository
    {
        Instructors Add(Instructors instructors);
        void Delete(int id);
        Instructors GetById(int id);
        IEnumerable<Instructors> GetList();
        Instructors Update(int id, Instructors instructors);
    }
}
