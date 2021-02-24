using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.ViewModels.Update
{
    public class UpdateHotelDto
    {
        public Guid Id { get; set; }

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