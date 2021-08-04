using CoreMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVCWebApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            HomeViewModel piesOfTheWeek = new HomeViewModel
            {
                PiesOfTheWeek = pieRepository.PiesOfTheWeek
            };
            return View(piesOfTheWeek);
        }
    }
}
