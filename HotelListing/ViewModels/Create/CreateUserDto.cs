using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.ViewModels.Create
{
    public class CreateUserDto
    {
        [Required,StringLength(20, MinimumLength = 2, ErrorMessage = "your First Name must between 2 and 20")]
        public string FirstName { get; set; }
        [Required,StringLength(20, MinimumLength = 2, ErrorMessage = "your Last Name must between 2 and 20")]
        public string LastName { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 2)]
        public string Password { get; set; }

        [Required] public IEnumerable<string> Roles { get; set; } = new List<string> {"user"};

    }
}
