using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //child ref
        public List<FreelanceProject> FreelanceProjects { get; set; }
    }
}
