using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplyingFactoryMethodToRepresentDifferentUI.Models;
using ApplyingFactoryMethodToRepresentDifferentUI.Creator.Intrface;
using ApplyingFactoryMethodToRepresentDifferentUI.Creator.Class;

namespace ApplyingFactoryMethodToRepresentDifferentUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ShowDifferentContent(int derivedModelType)
        {
            return ShowContentAccordingToType(derivedModelType);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private IActionResult ShowContentAccordingToType(int derivedModelType)
        {
            Dictionary<int, IModelCreator> ViewModels;
            ViewModels = new Dictionary<int, IModelCreator>();
            ViewModels.Add(1, new DerivedModel1Creator());
            ViewModels.Add(2, new DerivedModel2Creator());

            IModelCreator modelCreator = null;
            modelCreator = ViewModels.Where(S => S.Key == derivedModelType).First().Value;

           
            return modelCreator.Create();



        }
      
    }
}
