using Practical_13.Models.Context;
using Practical_13.Models.entities;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace Practical_13.Controllers
{
    public class DesignationController : Controller
    {
        AppDBContext context = new AppDBContext();
        // GET: Designation
        public ActionResult Index()
        {
            var data = context.Designations.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Designation d)
        {
            if (ModelState.IsValid)
            {
                context.Designations.Add(d);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);

        }

        public ActionResult Edit(int id)
        {
            var data = context.Designations.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Designation d)
        {
            if (ModelState.IsValid)
            {
                context.Entry(d).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }

        public ActionResult Delete(int id)
        {
            var data = context.Designations.Find(id);
            if(data != null)
            {
                context.Designations.Remove(data);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        
    }
}