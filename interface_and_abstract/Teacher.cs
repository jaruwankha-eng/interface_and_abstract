using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{

        public class Teacher : Person
        {
            // ==================== Properties ====================

            public string Major { get; set; }                           // สาขา
            public string AcademicPosition { get; set; }                // ตำแหน่งทางวิชาการ
            public List<string> TrainingResults { get; set; }
            public bool CanBeTrainer { get; set; }                      // สามารถเป็นวิทยากรได้

            // ==================== Constructors ====================

            public Teacher() : base()
            {
                Major = "";
                AcademicPosition = "";
                TrainingResults = new List<string>();
                CanBeTrainer = false;
            }

            public Teacher(string firstName, string lastName, string phone, string email,
                          string major, string academicPosition, bool canBeTrainer = false)
                : base(firstName,lastName, phone, email)
            {
                Major = major;
                AcademicPosition = academicPosition;
                TrainingResults = new List<string>();
                CanBeTrainer = canBeTrainer;
            }

            // ==================== Methods ====================

            public void EnableTrainer()
            {
                CanBeTrainer = true;
            }

            public void DisableTrainer()
            {
                CanBeTrainer = false;
            }

            public override string DisplayInfo()
            {
                string trainerStatus = CanBeTrainer ? " (เป็นวิทยากรได้)" : "";
                return $"{base.DisplayInfo()}, สาขา: {Major}, ตำแหน่ง: {AcademicPosition}{trainerStatus}";
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
