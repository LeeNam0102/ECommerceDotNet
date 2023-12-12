using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class UserRequestDto : RequestDtoBase
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(256)]
        [RegularExpression(@"^[a-zA-Z0-9_%+-]+@[a-zA-Z]+(\.[a-zA-Z]{2,4})+$", ErrorMessage = "Invalid Email format. Please enter a valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?!.*\s).*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).*$", ErrorMessage = "Password must contain uppercase letters, lowercase letters, digits and non-alphanumeric character and no spaces")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(0|\+84)[1-9]([0-9])(?!\2)[0-9]{7}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [StringLength(256)]
        public string? UserName { get; set; }
        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(256)]
        public string Avatar { get; set; }

        [StringLength(256)]
        public string Description { get; set; }
        [StringLength(256)]
        public string SecurityCode { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
