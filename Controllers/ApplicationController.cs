using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestI.Models;
using TestI.Models.ViewModels;

namespace TestI.Controllers
{
    public class ApplicationController : Controller
    {
        public readonly DataDbContext _db;

        public ApplicationController(DataDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Application> objList = _db.Applications;

            foreach (var obj in objList)
            {
                obj.Status = _db.Statuses.FirstOrDefault(u => u.StatusId == obj.StatusId);
                obj.Repair = _db.Repairs.FirstOrDefault(u => u.RepairId == obj.RepairId);
                obj.MachineTool = _db.MachineTools.FirstOrDefault(u => u.MachineToolsId == obj.MachineToolsId);
                obj.Client = _db.Clients.FirstOrDefault(u => u.ClientId == obj.ClientId);
            }
            return View(objList);
        }

        // GET-Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ApplicationViewModel applicationVM = new ApplicationViewModel()
            {
                Application = new Application(),
                TDDStatus = _db.Statuses.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusId.ToString()
                }),
                TDDClient = _db.Clients.Select(i => new SelectListItem
                {
                    Text = i.ClientName,
                    Value = i.ClientId.ToString()
                })
            };
            return View(applicationVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(ApplicationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Applications.Add(obj.Application);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Applications.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Applications.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Applications.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Update
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            ApplicationViewModel applicationVM = new ApplicationViewModel()
            {
                Application = new Application(),
                TDDStatus = _db.Statuses.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusId.ToString()
                }),
                TDDRepair = _db.Repairs.Select(i => new SelectListItem
                {
                    Text = i.RepairName,
                    Value = i.RepairId.ToString()
                }),
                TDDMachineTool = _db.MachineTools.Select(i => new SelectListItem
                {
                    Text = i.MachineToolsName,
                    Value = i.MachineToolsId.ToString()
                }),
                TDDClient = _db.Clients.Select(i => new SelectListItem
                {
                    Text = i.ClientName,
                    Value = i.ClientId.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            applicationVM.Application = _db.Applications.Find(id);
            if (applicationVM.Application == null)
            {
                return NotFound();
            }
            return View(applicationVM);
        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(ApplicationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Applications.Update(obj.Application);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _db.Applications.Include(b => b.Status).Include(c => c.Client).Include(c => c.Repair).Include(c => c.MachineTool)
            .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }
    }
}
