using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        public virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        private int vacationStock;
        public int VacationStock
        {
            get { return vacationStock; }
            set { vacationStock = value; }
        }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            int days = (to - from).Days;
            if (VacationStock >= days)
            {
                VacationStock -= days;
                return true;
            }
            else
            {
                VacationStock -= days;
                if (VacationStock < 0)
                {
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockNegative });
                }
                return false;
            }
        }

        public void EndOfYearOperation()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (age > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeExceeded });
            }
        }
    }
}
