using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace PortfolioProject.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        
        public byte[] Image { get; set; }
    }
}
