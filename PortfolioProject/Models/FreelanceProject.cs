using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class FreelanceProject
    {

        public int Id { get; set; }
        public Category Category { get; set; }
        public string Theme { get; set; }
        public string ProjectDespription { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public int PhoneNumber { get; set; }


    }
}
