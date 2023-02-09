using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyManagementPortal.Models;

namespace PropertyManagementPortal.Data
{
    public class PropertyManagementPortalContext : DbContext
    {
        public PropertyManagementPortalContext (DbContextOptions<PropertyManagementPortalContext> options)
            : base(options)
        {
        }

        public DbSet<PropertyManagementPortal.Models.Building> Building { get; set; } = default!;

        public DbSet<PropertyManagementPortal.Models.Apartment> Apartment { get; set; } = default!;
    }
}
