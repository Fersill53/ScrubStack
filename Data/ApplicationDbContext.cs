using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScrubStack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}