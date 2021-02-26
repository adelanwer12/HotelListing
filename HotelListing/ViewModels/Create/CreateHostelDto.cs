using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.ViewModels.Create
{
    public class CreateHostelDto
    {
        [Required]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "Hotel Name must be more than 6 Character and less than 50")]
        public string Name { get; set; }

        [Required]
        [StringLength(150,MinimumLength = 5, ErrorMessage = "Hotel Name must be more than 6 Character and less than 150")]
        public string Address { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }

        [Required]
        public Guid CountryId { get; set; }
    }
}
