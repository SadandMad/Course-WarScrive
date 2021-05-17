using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Data.Models;

namespace Course.ViewModels
{
    public class UnitsListViewModel {
        public IEnumerable<Unit> allUnits { get; set; }
        public string currCategory { get; set; }
    }
}
