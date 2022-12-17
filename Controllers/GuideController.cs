using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestI.Models;

namespace TestI.Controllers
{
    public class GuideController : Controller
    {
        private readonly DataDbContext _db;
        public GuideController(DataDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "admin, moderator, user")]
        public IActionResult Index()
        {
            IEnumerable<Guide> objList = _db.Guides;
            return View(objList);
        }

        //get-request?
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        //post-request??
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(Guide obj)
        {
            if (ModelState.IsValid)
            {
                _db.Guides.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Guides.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Guides.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Guides.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Update
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Guides.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Update(Guide obj)
        {
            if (ModelState.IsValid)
            {
                _db.Guides.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
