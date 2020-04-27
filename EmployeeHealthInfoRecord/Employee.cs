using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeHealthInfoRecord
{
    public class Employee : IComparable
    {
        public string GinNumber { get; set; }
        public string Name { get; set; }

        public Employee(string ginNumber, string name)
        {
            this.GinNumber = ginNumber;
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            Employee anotherEmployee = (Employee) obj;

            return string.Compare(this.Name, anotherEmployee.Name) != 0
                    ? string.Compare(this.Name, anotherEmployee.Name)
                    : int.Parse(this.GinNumber).CompareTo(int.Parse(anotherEmployee.GinNumber));
        }
    }
}
