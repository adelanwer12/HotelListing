using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }

        [StringLength(50,MinimumLength = 5, ErrorMessage = "Hotel Name must be more than 6 Character and less than 50")]
        public string Name { get; set; }

        [StringLength(150,MinimumLength = 5, ErrorMessage = "Hotel Name must be more than 6 Character and less than 150")]
        public string Address { get; set; }

        public double Rating { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }
    }
}
