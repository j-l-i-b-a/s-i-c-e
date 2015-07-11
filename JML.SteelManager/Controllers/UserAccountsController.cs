using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using JML.SteelIce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace JML.SteelIce.Controllers
{
    public class UserAccountsController : Controller
    {

        //this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));

        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly Guid owner = new Guid(System.Web.HttpContext.Current.User.Identity.GetUserId());

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private bool Employee
        {
            get
            {
                return db.UserAccount.Where(r => r.User_Id == owner && r.IsEmployee == true).Any();
            }
        }

        // GET: UserAccounts
        public async Task<ActionResult> Index()
        {
            return View(await db.UserAccount.Where(u => u.Owner == owner && u.User_Id != owner).ToListAsync());
        }

        // GET: UserAccounts/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccount.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            if (Employee)
                throw new HttpException(403, "Employee cannot create accounts..");

            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword,NotifyMeAboutActivity,ManageEmployees,ManageProjects,ManageCompany")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = employee.Email, Email = employee.Email };
                var result = await UserManager.CreateAsync(user, employee.Password);

                if (result.Succeeded)
                {
                    try
                    {
                        var userAccount = new UserAccount
                        {
                            Id = Guid.NewGuid(),
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            IsEmployee = true,
                            IsActive = true,
                            Owner = owner,
                            User_Id = new Guid(user.Id)
                        };

                        db.UserAccount.Add(userAccount);
                        await db.SaveChangesAsync();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        // Retrieve the error messages as a list of strings.
                        var errorMessages = ex.EntityValidationErrors
                                .SelectMany(x => x.ValidationErrors)
                                .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);

                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                    }
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            return View(employee);
        }

        // GET: UserAccounts/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccount.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,IsEmployee,NotifyMeAboutActivity,Photo,CompanyName,CompanyType,Established,EstablishedBy,ManageEmployees,ManageProjects,ManageCompany,IsActive")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = await db.UserAccount.FindAsync(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UserAccount userAccount = await db.UserAccount.FindAsync(id);
            db.UserAccount.Remove(userAccount);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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
