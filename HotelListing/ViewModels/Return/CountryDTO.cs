using System;
using System.Collections.Generic;

namespace HotelListing.ViewModels.Return
{
    public class CountryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }
        public IEnumerable<HotelDto> Hotels { get; set; }
        public IEnumerable<HostelDto> Hostels { get; set; }
    }
}
