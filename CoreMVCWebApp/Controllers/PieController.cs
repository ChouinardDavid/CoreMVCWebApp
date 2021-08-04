using CoreMVCWebApp.Models;
using CoreMVCWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVCWebApp.Controllers
{
    public class PieController: Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IPieRepository pieRepository;

        public PieController(ICategoryRepository categoryRepository, IPieRepository pieRepository)
        {
            this.categoryRepository = categoryRepository;
            this.pieRepository = pieRepository;
        }

        //public IActionResult List()
        //{
        //    var piesListViewModel = new PiesListViewModel()
        //    {
        //        Pies = pieRepository.AllPies,
        //        CurrentCategory = "Cheeses cakes"
        //    };
        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var pie = pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
