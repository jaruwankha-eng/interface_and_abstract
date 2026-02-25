using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{

        public class Trainer : Person
        {
            // ==================== Properties ====================

            public string Expertise { get; set; }                         // ความเชี่ยวชาญ
            public List<TrainingApproval> ApprovedTrainings { get; set; } // รายการอนุมัติ

            // ==================== Nested Class ====================

            public class TrainingApproval
            {
                public string ParticipantName { get; set; }
                public string Result { get; set; }
                public DateTime ApprovedDate { get; set; }

                public TrainingApproval(string participantName, string result)
                {
                    ParticipantName = participantName;
                    Result = result;
                    ApprovedDate = DateTime.Now;
                }
            }

            // ==================== Constructors ====================

            public Trainer() : base()
            {
                Expertise = "";
                ApprovedTrainings = new List<TrainingApproval>();
            }

            public Trainer(string firstName, string lastName, string phone, string email, string expertise)
                : base(firstName, lastName, phone, email)
            {
                Expertise = expertise;
                ApprovedTrainings = new List<TrainingApproval>();
            }

            // ==================== Methods ====================

            public override string DisplayInfo()
            {
                return $"{base.DisplayInfo()}, ความเชี่ยวชาญ: {Expertise}";
            }

            public void AddApprovedTraining(string participantName, string result)
            {
                ApprovedTrainings.Add(new TrainingApproval(participantName, result));
            }

            public int GetApprovedCount()
            {
                return ApprovedTrainings.Count;
            }

            public void PrintApprovedTrainings()
            {
                Console.WriteLine($"  รายชื่อผู้ที่ได้รับการอนุมัติ ({ApprovedTrainings.Count} คน):");
                foreach (var training in ApprovedTrainings)
                {
                    Console.WriteLine($"    - {training.ParticipantName}: {training.Result}");
                }
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
