using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tct_Magazina.ViewModels
{
    public class ManagerViewModel
    {

        [Key]
        public int ManagerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [Display(Name = "E-Mail Adress")]
        public string email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
