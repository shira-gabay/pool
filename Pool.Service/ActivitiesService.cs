using Pool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pool.Service.ActivitiesService;
using Pool.Core.Models;


namespace Pool.Service
{
    public class ActivitiesService
    {
        private readonly IActivitiesRepository _activitiesRepository;

        public ActivitiesService(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;   
        }
        public List<Activities> GetAll()
        {
            return _activitiesRepository.GetList().ToList();

        }
    }
}
