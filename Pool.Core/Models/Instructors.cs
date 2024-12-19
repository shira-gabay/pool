using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Models
{
    public class Instructors
    {
        public int Id { get; set; }
        public string Name { get; set; }       // שם המדריך
        public int Age { get; set; }            // גיל המדריך
        public int Experience { get; set; }     // שנות ניסיון
        public string Specialty { get; set; }   // תחום התמחות
        public string Phone { get; set; }       // מספר טלפון ליצירת קשר

    }
}
