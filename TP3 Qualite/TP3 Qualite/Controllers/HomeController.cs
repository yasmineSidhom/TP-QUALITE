using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3_Qualite.Models;

namespace TP3_Qualite.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBEntities _db = new MovieDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Table.ToList());
        }

        
        public ActionResult Details(int? id)
        {

            return View(_db.Table.Single(movie => movie.Id == id));
        }



        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid)

                    return View();

                _db.Table.Add(movieToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            var movieToEdit = (from m in _db.Table

                               where m.Id == id

                               select m).First();

            return View(movieToEdit);
        }

        /*/// POST: Home/Edit/5
        [HttpPost, ActionName("Edit")]
        public async ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                // TODO: Add update logic here

                var originalMovie = (from m in _db.Table

                                     where m.Id == movieToEdit.Id

                                     select m).First();

                if (await TryUpdateModelAsync<Movie>(
         originalMovie,
         "",
         s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
                {
                    try
                    {
                        await _context.SaveChangesAsync();

                        _db.SaveChanges();

                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }*/


        
        
        

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(_db.Table.Single(movie => movie.Id == id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movieToDelete)
        {
            try
            {
                // TODO: Add delete logic here

                movieToDelete = _db.Table.Single(movie => movie.Id == id);
                _db.Table.Remove(movieToDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
