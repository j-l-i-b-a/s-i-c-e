using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JML.SteelIce.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<UserAccount> UserAccount { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectRole> ProjectRole { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<JobPermissions> JobPermissions { get; set; }

        public DbSet<JobContributors> JobContributors { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Invitation> Invitation { get; set; }

        public DbSet<RFI> RFI { get; set; }

        public DbSet<RFIAnswer> RFIAnswer { get; set; }

        public DbSet<JobTask> JobTask { get; set; }

        public DbSet<ErrorList> ErrorList { get; set; }

        public DbSet<ErrorLog> ErrorLog { get; set; }

        public DbSet<Feedback> Feedback { get; set; }
    }
}