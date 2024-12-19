using Pool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Repositories
{
    public interface IActivitiesRepository
    {
        IEnumerable<Activities> GetAll();
        Activities Add(Activities activities);
        void Delete(int id);
        Activities GetById(int id);
        IEnumerable<Activities> GetList();
        Activities Update(int id, Activities activities);
    }
}
