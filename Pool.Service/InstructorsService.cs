using Pool.Core.Models;
using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Service
{
    public class InstructorsService
    {
        private readonly IInstructorsRepository _instructorsRepository;

        public InstructorsService(IInstructorsRepository instructorsRepository)
        {
            _instructorsRepository = instructorsRepository;
        }
        public List<Instructors> GetAll()
        {
            return _instructorsRepository.GetList().ToList();
        }
    }
}
