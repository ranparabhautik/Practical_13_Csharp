using Microsoft.Ajax.Utilities;
using Practical_13.Models.Context;
using Practical_13.Models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_13.Controllers
{
    public class EmployeeController : Controller
    {
        AppDBContext context = new AppDBContext();
        // GET: Employee


        public ActionResult Index() 
        {
            List<Employees> employeeList = new List<Employees>();
            using (var context =new  AppDBContext())
            {
                employeeList = context.Employees.ToList();
            }
            return View(employeeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees emp)
        {
           
                context.Employees.Add(emp);
                context.SaveChanges();
            
            return RedirectToAction("Index", "Employee");
        }

     
        public ActionResult Edit(int id)
        {
            var user = context.Employees.Where(x => x.id == id).FirstOrDefault();
            return View(user);  
        }

        [HttpPost]
        public ActionResult Edit(Employees emp)
        {
            var employee = context.Employees.Where(x => x.id == emp.id).FirstOrDefault();
            if(employee != null)
            {
                employee.name = emp.name;
                employee.DOB = emp.DOB;
                employee.age = emp.age;
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Employee");
        }


        public ActionResult Delete(int id)
        {
            var emp = context.Employees.Where(x => x.id == id).FirstOrDefault();
            if(emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Employee");
        }

    }
}