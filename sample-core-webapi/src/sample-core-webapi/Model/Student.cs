using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sample_core_webapi.Model
{
    public class Student
    {
        public Student()
        {

        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        [NotMapped]
        public string edit { get; set; }
        public Standard Standard { get; set; }

    }

    public class Standard
    {
        public Standard()
        {

        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }

}
