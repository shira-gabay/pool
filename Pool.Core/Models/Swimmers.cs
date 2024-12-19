using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool.Core.Models
{
    public class Swimmers
    {
        public int Id { get; set; }          // תז מדריך
        public string Name { get; set; }        // שם השוחה
            public int Age { get; set; }          // גיל השוחה
            public string Level { get; set; }      // רמת השחייה: מתחיל, בינוני, מתקדם
            public string Email { get; set; }       // כתובת אימייל
            public string Phone { get; set; }       // מספר טלפון ליצירת קשר
        
    }
}
