using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{

        public class GeneralPublic : Person
        {
            // ==================== Properties ====================

            public string Workplace { get; set; }      // สถานที่ทำงาน
            public string Position { get; set; }       // ตำแหน่ง
            public List<string> TrainingResults { get; set; }
            public bool CanBeTrainer { get; set; }     // สามารถเป็นวิทยากรได้

            // ==================== Constructors ====================

            public GeneralPublic() : base()
            {
                Workplace = "";
                Position = "";
                TrainingResults = new List<string>();
                CanBeTrainer = false;
            }

            public GeneralPublic(string firstName, string lastName, string phone, string email,
                                string workplace, string position, bool canBeTrainer = false)
                : base(firstName, lastName, phone, email)
            {
                Workplace = workplace;
                Position = position;
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
                return $"{base.DisplayInfo()}, สถานที่ทำงาน: {Workplace}, ตำแหน่ง: {Position}{trainerStatus}";
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
