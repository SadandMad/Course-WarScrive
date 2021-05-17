using Course.Data.Interfaces;
using Course.Data.Models;
using Course.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IAllUnits _allUnits;
        private readonly IUnitsCategory _allCategories;

        public UnitsController(IAllUnits allUnits, IUnitsCategory allCategories)
        {
            _allUnits = allUnits;
            _allCategories = allCategories;
        }
        [Route("Units/List")]
        [Route("Units/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Unit> units = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                units = _allUnits.getUnits.OrderBy(i => i.Id);
            }
            else
            {
                bool flFind = false;
                foreach (Category cat in _allCategories.getAllCategories.OrderBy(i => i.Id)) {
                    if (string.Equals(cat.Name, category, StringComparison.OrdinalIgnoreCase))
                    {
                        flFind = true;
                        ViewBag.Title = "Список юнитов";
                        units = _allUnits.getUnits.Where(i => i.Category.Name.Equals(cat.Name)).OrderBy(i => i.Id);
                    }
                }
                /*if (string.Equals("HQ", category, StringComparison.OrdinalIgnoreCase))
                {
                    units = _allUnits.getUnits.Where(i => i.Category.Name.Equals("HQ")).OrderBy(i => i.Id);
                }
                else
                {
                    if (string.Equals("Troops", category, StringComparison.OrdinalIgnoreCase))
                    {
                        units = _allUnits.getUnits.Where(i => i.Category.Name.Equals("Troops")).OrderBy(i => i.Id);
                    }
                    else
                    {
                        if (string.Equals("Elites", category, StringComparison.OrdinalIgnoreCase))
                        {
                            units = _allUnits.getUnits.Where(i => i.Category.Name.Equals("Elites")).OrderBy(i => i.Id);
                        }
                        else
                        {
                            if (string.Equals("Heavy Support", category, StringComparison.OrdinalIgnoreCase))
                            {
                                units = _allUnits.getUnits.Where(i => i.Category.Name.Equals("Heavy Support")).OrderBy(i => i.Id);
                            }
                            else
                            {
                                if (string.Equals("Fast Attack", category, StringComparison.OrdinalIgnoreCase))
                                {
                                    units = _allUnits.getUnits.Where(i => i.Category.Name.Equals("Fast Attack")).OrderBy(i => i.Id);
                                }
                            }
                        }
                    }
                }*/
                if (!flFind)
                {
                    ViewBag.Title = "Поиск юнитов";
                    units = _allUnits.getUnits.Where(i => i.Name.Contains(category, StringComparison.OrdinalIgnoreCase));
                }
            }
            currCategory = _category;
            var unitObj = new UnitsListViewModel
            {
                allUnits = units,
                currCategory = currCategory
            };
            return View(unitObj);
        }
    }
}