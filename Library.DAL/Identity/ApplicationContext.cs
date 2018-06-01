using System.Security.Claims;
using System.Threading.Tasks;
using Library.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Library.DAL.Identity
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
