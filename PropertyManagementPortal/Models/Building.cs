using Microsoft.EntityFrameworkCore;
using PropertyManagementPortal.Models;

namespace PropertyManagementPortal.Models
{
    public class Building
    {
        
        public int Id { get; set; }
        public string OwnerName { get; set; }

        public string TypeOfBuilding { get; set; }

        public string AddressOfBuilding { get; set; }


    }
}

