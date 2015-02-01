using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JML.SteelIce.Models;

namespace JML.SteelIce.Controllers
{
    public class UserAccountModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAccountModels
        public async Task<ActionResult> Index()
        {
            return View(await db.UserAccount.ToListAsync());
        }

        // GET: UserAccountModels/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccountModel = await db.UserAccount.FindAsync(id);
            if (userAccountModel == null)
            {
                return HttpNotFound();
            }
            return View(userAccountModel);
        }

        // GET: UserAccountModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccountModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,IsEmployee,NotifyMeAboutActivity,Photo,CompanyName,CompanyType,Established,EstablishedBy,ManageEmployees,ManageProjects,ManageCompany,IsActive")] UserAccount userAccountModel)
        {
            if (ModelState.IsValid)
            {
                userAccountModel.Id = Guid.NewGuid();
                //userAccountModel.User
                db.UserAccount.Add(userAccountModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userAccountModel);
        }

        // GET: UserAccountModels/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccountModel = await db.UserAccount.FindAsync(id);
            if (userAccountModel == null)
            {
                return HttpNotFound();
            }
            return View(userAccountModel);
        }

        // POST: UserAccountModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserAccountId,FirstName,LastName,IsEmployee,NotifyMeAboutActivity,Photo,CompanyName,CompanyType,Established,EstablishedBy,ManageEmployees,ManageProjects,ManageCompany,IsActive")] UserAccount userAccountModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccountModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userAccountModel);
        }

        // GET: UserAccountModels/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccountModel = await db.UserAccount.FindAsync(id);
            if (userAccountModel == null)
            {
                return HttpNotFound();
            }
            return View(userAccountModel);
        }

        // POST: UserAccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UserAccount userAccountModel = await db.UserAccount.FindAsync(id);
            db.UserAccount.Remove(userAccountModel);
            await db.SaveChangesAsync();
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
