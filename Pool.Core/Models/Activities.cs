using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Models
{
    public class Activities
    {

        public int Id { get; set; }
        public string Name { get; set; }         // שם הפעילות
        public DateTime Date { get; set; }       // תאריך הפעילות
        public Instructors Instructor { get; set; } // המדריך המוביל
        public string Level { get; set; }        // רמת הפעילות (מתחיל, בינוני, מתקדם)
        public int MaxParticipants { get; set; } // מספר משתתפים מקסימלי


    }
}
