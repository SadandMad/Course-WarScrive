using Course.Data.Interfaces;
using Course.Data.Models;
using Course.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Course.Controllers
{
    public class RosterController: Controller {
        private readonly IAllUnits _unitRep;
        private readonly Roster _roster;
        public RosterController(IAllUnits unitRep, Roster roster) {
            _unitRep = unitRep;
            _roster = roster;
        }
        public ViewResult Index() {
            var items = _roster.getRosterItems();
            _roster.listRosterItems = items;

            var obj = new RosterViewModel {
                roster = _roster
            };

            return View(obj);
        }
        public RedirectToActionResult addToRoster(int id) {
            var item = _unitRep.getUnits.FirstOrDefault(i => i.Id == id);
            if (item != null) {
                _roster.AddToRoster(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult deleteFromRoster(int id) {
            _roster.deleteFromRoster(id);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult clearRoster()
        {
            _roster.clearRoster();
            return RedirectToAction("Index");
        }
    }
}
