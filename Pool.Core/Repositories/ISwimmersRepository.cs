using Pool.Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Repositories
{
    public interface ISwimmersRepository
    {
        Swimmers Add(Swimmers swimmers);
        void Delete(int id);
        Swimmers GetById(int id);
        IEnumerable<Swimmers> GetList();
        Swimmers Update(int id, Swimmers swimmers);
    }
}
