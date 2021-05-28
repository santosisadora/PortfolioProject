using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Controllers
{
    public class VideosController : Controller
    {
        public IActionResult Index()
        {
            var videos = new List<Video>();

            videos.Add(new Video { Id = 100, Name = "Video Project 1", ReleaseYear = 2009 });
            videos.Add(new Video { Id = 101, Name = "Video Project 2", ReleaseYear = 2015 });
            videos.Add(new Video { Id = 102, Name = "Video Project 3", ReleaseYear = 2016 });
            videos.Add(new Video { Id = 103, Name = "Video Project 4", ReleaseYear = 2018 });
            
            return View(videos);

        }
        // gets:  /Videos/Details?name=VideoProjectnumber
        public IActionResult Details(string ProjectName)
        {
            // Read the name param from the url, and put it in the ViewBag for display on this view
            ViewBag.ProjectName = ProjectName;
            return View();
        }
    }
}
