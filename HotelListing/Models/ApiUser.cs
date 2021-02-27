using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Models
{
    public class ApiUser: IdentityUser
    {
        [StringLength(50, MinimumLength = 5,ErrorMessage ="your first name must be between 5 and 50 character")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 5,ErrorMessage ="your first name must be between 5 and 50 character")]
        public string LastName { get; set; }
    }
}
