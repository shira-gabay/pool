using Microsoft.EntityFrameworkCore;
using Pool.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pool
{
    public class DataContext:DbContext
    {
        public DbSet<Instructors> Instructors { get; set; }

        public DbSet<Swimmers> Swimmers { get; set; }
        public DbSet<Activities> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db");
            optionsBuilder.LogTo(massage=>Debug.WriteLine(massage));
        }
        //public DataContext()
        //{
        //    // אתחול רשימת המדריכים
        //    Instructors = new List<Instructors>
        //    {
        //        new Instructors { Id = 1, Name = "יוסי", Age = 30, Experience = 5, Specialty = "שחיית גב", Phone = "050-1234567" },
        //        new Instructors { Id = 2, Name = "מיכל", Age = 28, Experience = 3, Specialty = "שחיי", Phone = "050-2345678" },
        //        new Instructors { Id = 3, Name = "רמי", Age = 35, Experience = 10, Specialty = "שחיית פרפר", Phone = "050-3456789" },
        //        new Instructors { Id = 4, Name = "עדי", Age = 32, Experience = 7, Specialty = "שחיית חופשי", Phone = "050-4567890" },
        //        new Instructors { Id = 5, Name = "טל", Age = 26, Experience = 2, Specialty = "שחיית מים פתוחים", Phone = "050-5678901" }
        //    };

        //    // אתחול רשימת השחיינים
        //    Swimmers = new List<Swimmers>
        //    {
        //        new Swimmers { Id = 1, Name = "דניאל", Age = 12, Level = "מתחיל", Email = "daniel@example.com", Phone = "050-6789012" },
        //        new Swimmers { Id = 2, Name = "נועה", Age = 14, Level = "בינוני", Email = "noa@example.com", Phone = "050-7890123" },
        //        new Swimmers { Id = 3, Name = "איתי", Age = 11, Level = "מתקדם", Email = "itai@example.com", Phone = "050-8901234" },
        //        new Swimmers { Id = 4, Name = "מאיה", Age = 15, Level = "מתחיל", Email = "maya@example.com", Phone = "050-9012345" },
        //        new Swimmers { Id = 5, Name = "עומר", Age = 13, Level = "בינוני", Email = "omer@example.com", Phone = "050-0123456" }
        //    };

        //    // אתחול רשימת הפעילויות
        //    Activities = new List<Activities>
        //    {
        //        new Activities { Id = 1, Name = "שחייה מהירה", Date = new DateTime(2024, 10, 15), Instructor = Instructors[1], Level = "בינוני", MaxParticipants = 10 },
        //        new Activities { Id = 2, Name = "שחיית סגנונות", Date = new DateTime(2024, 10, 16), Instructor = Instructors[1], Level = "מתחיל", MaxParticipants = 12 },
        //        new Activities { Id = 3, Name = "תחרות שחייה", Date = new DateTime(2024, 10, 17), Instructor = Instructors[2], Level = "מתקדם", MaxParticipants = 15 },
        //        new Activities { Id = 4, Name = "שחיית פרפר", Date = new DateTime(2024, 10, 18), Instructor = Instructors[3], Level = "בינוני", MaxParticipants = 8 },
        //        new Activities { Id = 5, Name = "שחייה חופשית", Date = new DateTime(2024, 10, 19), Instructor = Instructors[4], Level = "מתחיל", MaxParticipants = 20 }
        //    };
        //}
    }
}
