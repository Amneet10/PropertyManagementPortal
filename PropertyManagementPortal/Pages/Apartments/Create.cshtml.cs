using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PropertyManagementPortal.Data;
using PropertyManagementPortal.Models;

namespace PropertyManagementPortal.Pages.Apartments
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PropertyManagementPortal.Data.PropertyManagementPortalContext _context;

        public CreateModel(PropertyManagementPortal.Data.PropertyManagementPortalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; } = default!;

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            Console.WriteLine("building id is "+ Id);

            if (!ModelState.IsValid )
            {               
               return Page();
            }

            var building = await _context.Building.FindAsync(Id);
            if (building == null)
            {
                return NotFound();
            }

            var apartment = new Apartment
            {
                TypeOfApartment = Apartment.TypeOfApartment,
                ApartmentNumber = Apartment.ApartmentNumber,
                Rent = Apartment.Rent,
                RenterName= Apartment.RenterName,
                BuildingId = Id
            };

            _context.Apartment.Add(apartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = Id });
        }
    }
}
