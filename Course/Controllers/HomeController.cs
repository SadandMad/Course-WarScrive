using Course.Data.Interfaces;
using Course.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class HomeController: Controller {
        private readonly IAllUnits _unitRep;
        public HomeController(IAllUnits unitRep) {
            _unitRep = unitRep;
        }

        public ViewResult Index() {
            var homeUnits = new HomeViewModel
            {
                favUnits = _unitRep.getFavouriteUnits
            };
            return View(homeUnits);
        }
    }
}