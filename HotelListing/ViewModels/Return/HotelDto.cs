using System;

namespace HotelListing.ViewModels.Return
{
    public class HotelDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Rating { get; set; }
        public Guid CountryId { get; set; }

    }
}
