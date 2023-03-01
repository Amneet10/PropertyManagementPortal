using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PropertyManagementPortal.Data;
using PropertyManagementPortal.Models;

namespace PropertyManagementPortal.Pages.Apartments
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PropertyManagementPortal.Data.PropertyManagementPortalContext _context;

        public IndexModel(PropertyManagementPortal.Data.PropertyManagementPortalContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get;set; } = default!;

        public async Task OnGetAsync(int Id)
        {
            ViewData["Id"] = Id;    
            if (_context.Apartment != null)
            {
                Apartment = await _context.Apartment.Where(a => a.BuildingId == Id).ToListAsync();

            }
        }
    }
}
