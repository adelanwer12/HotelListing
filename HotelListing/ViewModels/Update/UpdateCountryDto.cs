using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.ViewModels.Update
{
    public class UpdateCountryDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "Country Name must be more than 6 Character and less than 50")]
        public string Name { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "Country Short Name Name must be more than 6 Character and less than 50")]
        public string ShortName { get; set; }
    }
}