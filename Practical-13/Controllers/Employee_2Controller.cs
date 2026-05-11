using Practical_13.Models.Context;
using Practical_13.Models.ViewModel;
using Practical_13.Models.entities;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.Design.Serialization;

namespace Practical_13.Controllers
{
    public class Employee_2Controller : Controller
    {
        // GET: Employee_2
        AppDBContext context = new AppDBContext();  
        public ActionResult Index()
        {
            var emps = context.Employees_Task2.ToList();
            return View(emps);
        }

        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "DesignationName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees_Task2 e)
        {
            if (ModelState.IsValid)
            {
                context.Employees_Task2.Add(e);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "DesignationName", e.DesignationId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = context.Employees_Task2.Find(id);
            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "DesignationName", data.DesignationId);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employees_Task2 e)
        {
            if (ModelState.IsValid)
            {
                context.Entry(e).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "DesignationName", e.DesignationId);
            return View(e);
        }

        public ActionResult Delete(int id)
        {
            var data = context.Employees_Task2.Find(id);
            if(data != null)
            {
                context.Employees_Task2.Remove(data);
                context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeDetails()
        {
            var employee = context.Employees_Task2.Select(e => new EmployeeVM
            {
               Id = e.Id,
                First_name = e.First_name,
                Middle_name = e.Middle_name,
                Last_name=  e.Last_name,
                DOB = e.DOB,
                Salary = e.Salary,
                MobileNumber=  e.MobileNumber,
                Address= e.Address,
                Desig = e.Designation.DesignationName
            }).ToList();

            return View(employee);
        }

        public ActionResult CountEmpByDesignation()
        {
            var data = context.Employees_Task2.GroupBy(e => e.Designation.DesignationName).Select(x => new CountEmp
            {
                Designation = x.Key,
                Count = x.Count()
            }).ToList();

            
            return View(data);
        }


    }
}