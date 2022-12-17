using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestI.Models;

namespace TestI.Controllers
{
    public class ClientController : Controller
    {
        private readonly DataDbContext _db;
        public ClientController(DataDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "admin, moderator, user")]
        public IActionResult Index()
        {
            IEnumerable<Client> objList = _db.Clients;
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
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(obj);
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
            var obj = _db.Clients.Find(id);
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
            var obj = _db.Clients.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Clients.Remove(obj);
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
            var obj = _db.Clients.Find(id);
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
        public IActionResult Update(Client obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
