using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class FreelanceProject
    {

        public int Id { get; set; }
        public Category Category { get; set; }
        public string Theme { get; set; }

        [Display(Name ="Project Description")]
        public string ProjectDespription { get; set; }

        [Display(Name = "Expected Date")]
        public DateTime ExpectedDate { get; set; }

        [Display(Name = "First Name")]
        public string FirstName{ get; set; }


        [Display(Name = "Last Name")]
        public string LastName{ get; set; }
        public string Email{ get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }


    }
}
