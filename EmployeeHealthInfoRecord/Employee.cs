using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeHealthInfoRecord
{
    public class Employee
    {
        public string GinNumber { get; set; }
        public string Name { get; set; }

        public Employee(string ginNumber, string name)
        {
            this.GinNumber = ginNumber;
            this.Name = name;
        }
    }
}
