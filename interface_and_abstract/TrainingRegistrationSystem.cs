using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{
    
        public class TrainingRegistrationSystem
        {
            // ==================== Properties ====================

            private List<Student> students;
            private List<Teacher> teachers;
            private List<GeneralPublic> generalPublic;
            private List<Trainer> trainers;
            private List<Person> registrations;

            // ==================== Constructors ====================

            public TrainingRegistrationSystem()
            {
                students = new List<Student>();
                teachers = new List<Teacher>();
                generalPublic = new List<GeneralPublic>();
                trainers = new List<Trainer>();
                registrations = new List<Person>();
            }

            // ==================== ฟังก์ชันลงทะเบียน ====================

            /// <summary>
            /// ลงทะเบียนนักศึกษา
            /// </summary>
            public Student RegisterStudent(string firstName, string lastName, string phone,
                                            string email, string major, string studentId)
            {
                Student student = new Student(firstName, lastName, phone, email, major, studentId);
                students.Add(student);
                registrations.Add(student);
                return student;
            }

            /// <summary>
            /// ลงทะเบียนอาจารย์
            /// </summary>
            public Teacher RegisterTeacher(string firstName, string lastName, string phone,
                                            string email, string major, string academicPosition,
                                            bool canBeTrainer = false)
            {
                Teacher teacher = new Teacher(firstName, lastName, phone, email, major, academicPosition, canBeTrainer);
                teachers.Add(teacher);
                registrations.Add(teacher);
                return teacher;
            }

            /// <summary>
            /// ลงทะเบียนบุคคลทั่วไป
            /// </summary>
            public GeneralPublic RegisterGeneralPublic(string firstName, string lastName, string phone,
                                                         string email, string workplace, string position,
                                                         bool canBeTrainer = false)
            {
                GeneralPublic person = new GeneralPublic(firstName, lastName, phone, email, workplace, position, canBeTrainer);
                generalPublic.Add(person);
                registrations.Add(person);
                return person;
            }

            /// <summary>
            /// ลงทะเบียนวิทยากร
            /// </summary>
            public Trainer RegisterTrainer(string firstName, string lastName, string phone,
                                            string email, string expertise)
            {
                Trainer trainer = new Trainer(firstName, lastName, phone, email, expertise);
                trainers.Add(trainer);
                return trainer;
            }

            // ==================== ฟังก์ชันแปลงเป็นวิทยากร ====================

            /// <summary>
            /// แปลงอาจารย์เป็นวิทยากร
            /// </summary>
            public Trainer ConvertTeacherToTrainer(Teacher teacher)
            {
                if (teacher == null) return null;

                teacher.EnableTrainer();
                string expertise = $"วิทยากรจากสาขา {teacher.Major}";

                Trainer newTrainer = new Trainer(
                    teacher.FirstName,
                    teacher.LastName,
                    teacher.Phone,
                    teacher.Email,
                    expertise
                );

                trainers.Add(newTrainer);
                return newTrainer;
            }

            /// <summary>
            /// แปลงบุคคลทั่วไปเป็นวิทยากร
            /// </summary>
            public Trainer ConvertGeneralPublicToTrainer(GeneralPublic person)
            {
                if (person == null) return null;

                person.EnableTrainer();
                string expertise = $"วิทยากรจาก {person.Workplace}";

                Trainer newTrainer = new Trainer(
                    person.FirstName,
                    person.LastName,
                    person.Phone,
                    person.Email,
                    expertise
                );

                trainers.Add(newTrainer);
                return newTrainer;
            }

            // ==================== ฟังก์ชันอนุมัติผลการอบรม ====================

            /// <summary>
            /// อนุมัติผลการอบรม (เฉพาะวิทยากร)
            /// </summary>
            public bool ApproveTrainingResult(Trainer trainer, Person participant, string result)
            {
                if (trainer == null || participant == null) return false;

                // เพิ่มผลการอบรมให้ผู้เข้าร่วม
                if (participant is Student)
                {
                    ((Student)participant).AddTrainingResult(result);
                }
                else if (participant is Teacher)
                {
                    ((Teacher)participant).AddTrainingResult(result);
                }
                else if (participant is GeneralPublic)
                {
                    ((GeneralPublic)participant).AddTrainingResult(result);
                }

                // เพิ่มการอนุมัติให้วิทยากร
                trainer.AddApprovedTraining(participant.GetFullName(), result);

                return true;
            }

            // ==================== ฟังก์ชันแสดงข้อมูล ====================

            /// <summary>
            /// แสดงรายชื่อผู้เข้าอบรมทั้งหมด
            /// </summary>
            public void DisplayAllParticipants()
            {
                Console.WriteLine("\n" + "============================================================");
                Console.WriteLine("รายชื่อผู้เข้าอบรมทั้งหมด");
                Console.WriteLine("============================================================");

                if (registrations.Count == 0)
                {
                    Console.WriteLine("ไม่มีผู้ลงทะเบียนเข้าอบรม");
                    return;
                }

                Console.WriteLine($"\nจำนวนผู้ลงทะเบียนทั้งหมด: {registrations.Count} คน\n");

                // แสดงนักศึกษา
                if (students.Count > 0)
                {
                    Console.WriteLine($" นักศึกษา ({students.Count} คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {students[i].DisplayInfo()}");
                    }
                    Console.WriteLine();
                }

                // แสดงอาจารย์
                if (teachers.Count > 0)
                {
                    Console.WriteLine($" อาจารย์ ({teachers.Count} คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < teachers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {teachers[i].DisplayInfo()}");
                    }
                    Console.WriteLine();
                }

                // แสดงบุคคลทั่วไป
                if (generalPublic.Count > 0)
                {
                    Console.WriteLine($" บุคคลทั่วไป ({generalPublic.Count} คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < generalPublic.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {generalPublic[i].DisplayInfo()}");
                    }
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// แสดงรายชื่อวิทยากรทั้งหมด
            /// </summary>
            public void DisplayAllTrainers()
            {
                Console.WriteLine("\n" + "============================================================");
                Console.WriteLine("รายชื่อวิทยากรทั้งหมด");
                Console.WriteLine("============================================================");

                if (trainers.Count == 0)
                {
                    Console.WriteLine("ไม่มีวิทยากรในระบบ");
                    return;
                }

                Console.WriteLine($"\nจำนวนวิทยากรทั้งหมด: {trainers.Count} คน\n");

                for (int i = 0; i < trainers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {trainers[i].DisplayInfo()}");
                    if (trainers[i].ApprovedTrainings.Count > 0)
                    {
                        trainers[i].PrintApprovedTrainings();
                    }
                }
                Console.WriteLine();
            }

            // ==================== Getter Functions ====================

            public List<Student> GetStudents() => students;
            public List<Teacher> GetTeachers() => teachers;
            public List<GeneralPublic> GetGeneralPublic() => generalPublic;
            public List<Trainer> GetTrainers() => trainers;
            public List<Person> GetAllRegistrations() => registrations;

            public int GetTotalParticipants() => registrations.Count;
            public int GetTotalTrainers() => trainers.Count;
            public int GetStudentCount() => students.Count;
            public int GetTeacherCount() => teachers.Count;
            public int GetGeneralPublicCount() => generalPublic.Count;

            // ==================== ฟังก์ชันค้นหา ====================

            /// <summary>
            /// ค้นหาผู้เข้าอบรมจากชื่อ
            /// </summary>
            public List<Person> SearchParticipant(string keyword)
            {
                List<Person> results = new List<Person>();
                keyword = keyword.ToLower();

                foreach (var person in registrations)
                {
                    if (person.GetFullName().ToLower().Contains(keyword))
                    {
                        results.Add(person);
                    }
                }
                return results;
            }

            /// <summary>
            /// ค้นหาวิทยากรจากชื่อ
            /// </summary>
            public List<Trainer> SearchTrainer(string keyword)
            {
                List<Trainer> results = new List<Trainer>();
                keyword = keyword.ToLower();

                foreach (var trainer in trainers)
                {
                    if (trainer.GetFullName().ToLower().Contains(keyword))
                    {
                        results.Add(trainer);
                    }
                }
                return results;
            }

            // ==================== ฟังก์ชันลบข้อมูล ====================

            /// <summary>
            /// ลบผู้เข้าอบรม
            /// </summary>
            public bool RemoveParticipant(Person participant)
            {
                if (participant == null) return false;

                if (registrations.Remove(participant))
                {
                    if (participant is Student) students.Remove((Student)participant);
                    else if (participant is Teacher) teachers.Remove((Teacher)participant);
                    else if (participant is GeneralPublic) generalPublic.Remove((GeneralPublic)participant);

                    return true;
                }
                return false;
            }

            /// <summary>
            /// ลบวิทยากร
            /// </summary>
            public bool RemoveTrainer(Trainer trainer)
            {
                return trainers.Remove(trainer);
            }

            // ==================== ฟังก์ชันแสดงสถานะระบบ ====================

            /// <summary>
            /// แสดงสถานะของระบบ
            /// </summary>
            public void GetSystemStatus()
            {
                Console.WriteLine("\n" + "============================================================");
                Console.WriteLine("สถานะระบบ");
                Console.WriteLine("============================================================");
                Console.WriteLine($"นักศึกษา: {GetStudentCount()} คน");
                Console.WriteLine($"อาจารย์: {GetTeacherCount()} คน");
                Console.WriteLine($"บุคคลทั่วไป: {GetGeneralPublicCount()} คน");
                Console.WriteLine($"วิทยากร: {GetTotalTrainers()} คน");
                Console.WriteLine($"ผู้เข้าอบรมทั้งหมด: {GetTotalParticipants()} คน");
                Console.WriteLine("============================================================");
            }

            public override string ToString()
            {
                return $"ระบบรับสมัครฝึกอบรม: ผู้เข้าอบรม {GetTotalParticipants()} คน, วิทยากร {GetTotalTrainers()} คน";
            }
        }
    
}

