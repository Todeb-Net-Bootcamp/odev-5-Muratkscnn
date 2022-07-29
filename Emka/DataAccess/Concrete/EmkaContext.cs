using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EmkaContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EmkaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Personel> Personels { get; set; }


    }
}
