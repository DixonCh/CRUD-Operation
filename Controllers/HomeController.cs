using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CRUDOPERATION.Models;
using CRUDOPERATION.Repository;

namespace CRUDOPERATION.Controllers
{
    public class HomeController : Controller
    {
        private ICourseRepository repo = new CourseRepository();
        public ActionResult Index()
        {


            return View(repo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                int result =repo.Insert(new Course()
                {
                    Name=cvm.Name,
                    Fees=cvm.Fees,
                    Status=cvm.Status
                });
                if(result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Unable to Insert";
                }
            }
            return View(cvm);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            int cId = id ?? 0;
            //if its not null then assign 0 value
            Course course = repo.Find(cId);
            if (course == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(new CourseViewModel()
            {
                Id=course.Id,
                Name=course.Name,
                Fees=course.Fees,
                Status=course.Status



            });
        }
        [HttpPost]
        public ActionResult Edit(CourseViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                repo.Update(new Course()
                {
                    Id=cvm.Id,
                    Name=cvm.Name,
                    Fees=cvm.Fees,
                    Status=cvm.Status


                });
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        }
}