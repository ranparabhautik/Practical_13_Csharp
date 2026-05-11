using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_13.Models.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Last_name { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Desig { get; set; }
    }
}