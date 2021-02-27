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

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual IEnumerable<Hotel> Hotels { get; set; }
        public virtual IEnumerable<Hostel> Hostels { get; set; }
    }
}
