using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        private List<Employee> staff = new List<Employee>();

        public void AddStaff(Employee e)
        {
            staff.Add(e);
            e.EmployeeLayOff += RemoveStaff;
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            Employee employee = sender as Employee;
            if (employee != null)
            {
                staff.Remove(employee);
                Console.WriteLine($"Employee {employee.EmployeeID} has been laid off due to {e.Cause}.");
            }
        }
    }
}
