namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department { DeptID = 1, DeptName = "HR" };

            Employee emp1 = new Employee { EmployeeID = 1, BirthDate = new DateTime(1950, 1, 1), VacationStock = 10 };
            Employee emp2 = new Employee { EmployeeID = 2, BirthDate = new DateTime(1980, 1, 1), VacationStock = 5 };

            dept.AddStaff(emp1);
            dept.AddStaff(emp2);

            emp1.RequestVacation(new DateTime(2023, 1, 1), new DateTime(2023, 1, 15)); // Employee 1 has been laid off due to VacationStockNegative.
            emp1.EndOfYearOperation(); // Employee 1 has been laid off due to AgeExceeded.

            emp2.RequestVacation(new DateTime(2023, 1, 1), new DateTime(2023, 1, 20)); // Employee 2 has been laid off due to VacationStockNegative.
        }
    }
}
