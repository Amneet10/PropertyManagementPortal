using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementPortal.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string TypeOfApartment { get; set; }

        public int ApartmentNumber { get; set; }

        public double Rent { get; set; }

        public string RenterName { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set;}
    }
}
