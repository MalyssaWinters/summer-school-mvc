using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using summer_school_mvc.Models;

namespace summer_school_mvc.Controllers
{
    public class StudentsController : Controller
    {
        private SummerSchoolMVCEntities db = new SummerSchoolMVCEntities();

        // GET: Students
        public ActionResult Index(string searchString)
        {
<<<<<<< HEAD
            var students = from item in db.Students
                           select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = from item in students
                           where item.LastName.Contains(searchString) ||
                                 item.FirstName.Contains(searchString)
                           select item;
            }

            //allows us to change the index view
            ViewBag.TotalEnrollmentFee = totalFees();
            ViewBag.MaximumEnrollment = 15;
            return View(students);

=======
            //allows us to change the index view
            ViewBag.TotalEnrollmentFee = TotalFees();
            return View(db.Students.ToList());
>>>>>>> 5eea4981698bb49caab226ca3b10afa5ee1953d2
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        int EnrollStudent(string firstName, string lastName)
        {
            double cost = 200;
            if (lastName.ToLower() == "potter")
            {
                cost *= 0.5;
            }
            int numberOfStudents = db.Students.Count();
            if (lastName.ToLower() == "longbottom" && numberOfStudents <= 10)
            {
                cost = 0;
            }
            if (firstName.ToLower()[0] == lastName.ToLower()[0])
            {
                cost = 0.9 * cost;
            }
            return (int)cost;
        }
<<<<<<< HEAD
        public decimal totalFees()
        {
            decimal runningTotal = 0;
=======

        public decimal TotalFees()
        {
            decimal runningTotal = 0;

>>>>>>> 5eea4981698bb49caab226ca3b10afa5ee1953d2
            foreach (Student student in db.Students)
            {
                runningTotal = runningTotal + student.EnrollmentFee;
            }
            return runningTotal;
        }
        
        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName")] Student student)
        {
            student.EnrollmentFee = EnrollStudent(student.FirstName, student.LastName);

            if (ModelState.IsValid)
            {
                db.Students.Add(student);
<<<<<<< HEAD
=======
                student.EnrollmentFee = Enrollment(student);
>>>>>>> 5eea4981698bb49caab226ca3b10afa5ee1953d2
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,EnrollmentFee")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
