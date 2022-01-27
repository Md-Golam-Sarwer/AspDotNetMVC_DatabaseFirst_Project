using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeInformationSystem.Models.ViewModel
{
    public class SalaryVM
    {
        public int SalaryID { get; set; }
        public int EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HouseRent { get; set; }
        public decimal TotalSalary { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee Employee { get; set; }
    }
}