using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerUi.Models
{
    public class PersonModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Gender { get; set; }

    }
}
