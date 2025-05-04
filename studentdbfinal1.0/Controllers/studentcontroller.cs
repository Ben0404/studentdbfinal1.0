using studentdb.Models.Repositories;
using studentdb;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using studentdbfinal1._0;
using System;

namespace studentdb.Controllers
{
    public class StudentController : Controller
    {
        private Istudentrepository repository;

        public StudentController()
        {
            this.repository = new StudentRepository();
        }

        public StudentController(Istudentrepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Studentquery1> model = repository.SelectAll().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Studentquery1 existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Studentquery1()); // <- instantiate model
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Studentquery1 obj)
        {
            if (ModelState.IsValid)
            {
                // Calculate the OverallModuleMark before saving
                obj.OverallModuleMark = obj.CalculateOverallModuleMark();

                try
                {
                    repository.Insert(obj);
                    repository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception message
                    System.Diagnostics.Debug.WriteLine("Error in Create: " + ex.Message);
                    ModelState.AddModelError("", "An error occurred while creating the student. Please try again.");
                }
            }
            else
            {
                // Log the validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Studentquery1 existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Studentquery1 obj)
        {
            if (ModelState.IsValid)
            {
                // Recalculate the OverallModuleMark before updating
                obj.OverallModuleMark = obj.CalculateOverallModuleMark();

                try
                {
                    repository.Update(obj);
                    repository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception message
                    System.Diagnostics.Debug.WriteLine("Error in Edit: " + ex.Message);
                    ModelState.AddModelError("", "An error occurred while updating the student. Please try again.");
                }
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repository.Delete(id);
                repository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in Delete: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Studentquery1 existing = repository.SelectByID(id);
            if (existing == null)
            {
                return HttpNotFound();
            }
            return View(existing);
        }
    }
}
