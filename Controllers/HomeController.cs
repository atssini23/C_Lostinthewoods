using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using YourNamespace.Factory;
using YourNamespace.Models;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }
        [HttpGet]
        [Route("NewTrail")]
        public IActionResult Show()
        {
            return View("Create");
        }
        [HttpPost]
        [Route("NewTrail")]
        public IActionResult Create(Trail trail)
        {
            trailFactory.Create(trail);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Trails/{trailId}")]
        public IActionResult Detail(int trailId)
        {
            ViewBag.Trail = trailFactory.FindByID(trailId);
            return View("Detail");
        }
    }
}
