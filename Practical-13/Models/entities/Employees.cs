using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_13.Models.entities
{
    public class Employees
    {
        public int id {  get; set; }
        public string name { get; set; }    
        public int age { get; set; }
        public DateTime DOB { get; set; }
    }
}