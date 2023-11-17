using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Infrastructure.Persistence.Contexts
{
    public class AppContextIdentity : IdentityDbContext<IdentityUser>
    {
        public AppContextIdentity(DbContextOptions<AppContextIdentity> options) : base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

    

}
