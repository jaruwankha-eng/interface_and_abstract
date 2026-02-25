using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{

        public class Student : Person
        {
            // ==================== Properties ====================

            public string Major { get; set; }       // สาขา
            public string StudentId { get; set; }   // รหัสนักศึกษา
            public List<string> TrainingResults { get; set; }

            // ==================== Constructors ====================

            public Student() : base()
            {
                Major = "";
                StudentId = "";
                TrainingResults = new List<string>();
            }

            public Student(string firstName, string lastName, string phone, string email,
                          string major, string studentId) : base(firstName, lastName, phone, email)
            {
                Major = major;
                StudentId = studentId;
                TrainingResults = new List<string>();
            }

            // ==================== Methods ====================

            public override string DisplayInfo()
            {
                return $"{base.DisplayInfo()}, สาขา: {Major}, รหัสนักศึกษา: {StudentId}";
            }

            public void AddTrainingResult(string result)
            {
                TrainingResults.Add(result);
            }

            public override string ToString()
            {
                return DisplayInfo();
            }

            public override void PrintInfo()
            {
                Console.WriteLine(DisplayInfo());
            }
        }
    
}
