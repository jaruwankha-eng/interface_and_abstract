using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_and_abstract
{

        public class Person
        {
            // ==================== Properties ====================

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

            // ==================== Constructors ====================

            public Person()
            {
                FirstName = "";
                LastName = "";
                Phone = "";
                Email = "";
            }

            public Person(string firstName, string lastName, string phone, string email)
            {
                FirstName = firstName;
                LastName = lastName;
                Phone = phone;
                Email = email;
            }

            // ==================== Methods ====================

            public string GetFullName()
            {
                return $"{FirstName} {LastName}";
            }

            public virtual string DisplayInfo()
            {
                return $"ชื่อ: {GetFullName()}, โทร: {Phone}, อีเมล: {Email}";
            }

            public override string ToString()
            {
                return DisplayInfo();
            }

            public virtual void PrintInfo()
            {
                Console.WriteLine(DisplayInfo());
            }
        }
    
}

