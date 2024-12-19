using Pool.Core.Models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Service
{
    public class SwimmersService
    {
        private readonly ISwimmersRepository _swimmersRepository;

        public SwimmersService(ISwimmersRepository swimmersRepository)
        {
            _swimmersRepository = swimmersRepository;
        }
        public List<Swimmers> GetAll()
        {
            return _swimmersRepository.GetList().ToList();
        }

    }
}
