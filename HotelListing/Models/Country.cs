using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class Country
    {
        public Guid Id { get; set; }

        [StringLength(50,MinimumLength = 5, ErrorMessage = "Country Name must be more than 6 Character and less than 50")]
        public string Name { get; set; }

        [StringLength(50,MinimumLength = 5, ErrorMessage = "Country Short Name Name must be more than 6 Character and less than 50")]
        public string ShortName { get; set; }

        public virtual IEnumerable<Hotel> Hotels { get; set; }
        public virtual IEnumerable<Hostel> Hostels { get; set; }
    }
}
