using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_core_webapi.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }


        public Student ToStudent()
        {
            Student student = new Student();
            student.StudentID = Id;
            student.StudentName = Name;
            student.Height = Decimal.Parse(Height);
            student.Weight = float.Parse(Weight);
            return student;
        }
    }

    public static partial class Extensions
    {
        public static StudentModel ToViewModel(this Student student)
        {
            StudentModel stdModel = new StudentModel()
            {
                Id = student.StudentID,
                Name = student.StudentName,
                Weight = student.Weight.ToString(),
                Height = student.Height.ToString()
            };

            return stdModel;
        }
    }
}
