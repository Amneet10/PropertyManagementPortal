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
    public class IndexModel : PageModel
    {
        private readonly PropertyManagementPortal.Data.PropertyManagementPortalContext _context;

        public IndexModel(PropertyManagementPortal.Data.PropertyManagementPortalContext context)
        {
            _context = context;
        }
        public string OwnerName { get; set; }
        public string TypeOfBuilding { get; set; }
        public string AddressOfBuilding { get; set; }
        

        public IList<Building> Buildings { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            OwnerName = sortOrder == "OwnerName" ? "OwnerName_desc" : "OwnerName";
            TypeOfBuilding = sortOrder == "TypeOfBuilding"? "TypeOfBuilding_desc" : "TypeOfBuilding";
            AddressOfBuilding = sortOrder == "AddressOfBuilding" ? "AddressOfBuilding_desc" : "AddressOfBuilding";


            IQueryable<Building> BuildingsIQ = from s in _context.Building
                                             select s;

            switch (sortOrder)
            {
                case "OwnerName":
                    BuildingsIQ = BuildingsIQ.OrderBy(s => s.OwnerName);
                    break;
                case "OwnerName_desc":
                    BuildingsIQ = BuildingsIQ.OrderByDescending(s => s.OwnerName);
                    break;
                case "TypeOfBuilding":
                    BuildingsIQ = BuildingsIQ.OrderBy(s => s.TypeOfBuilding);
                    break;
                case "TypeOfBuilding_desc":
                    BuildingsIQ = BuildingsIQ.OrderByDescending(s => s.TypeOfBuilding);
                    break;
                case "AddressOfBuilding":
                    BuildingsIQ = BuildingsIQ.OrderBy(s => s.AddressOfBuilding);
                    break;
                case "AddressOfBuilding_desc":
                    BuildingsIQ = BuildingsIQ.OrderByDescending(s => s.AddressOfBuilding);
                    break;
                default:
                    BuildingsIQ = BuildingsIQ.OrderBy(s => s.Id);
                    break;
            }
            
            Buildings = await BuildingsIQ.AsNoTracking().ToListAsync();
        }

       
    }
}
