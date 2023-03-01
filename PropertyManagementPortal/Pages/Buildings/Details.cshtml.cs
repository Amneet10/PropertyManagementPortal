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

namespace PropertyManagementPortal.Pages.Buildings
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly PropertyManagementPortal.Data.PropertyManagementPortalContext _context;

        public DetailsModel(PropertyManagementPortal.Data.PropertyManagementPortalContext context)
        {
            _context = context;
        }

      public Building Building { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Building == null)
            {
                return NotFound();
            }

            var building = await _context.Building.FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            else 
            {
                Building = building;
            }
            return Page();
        }
    }
}
