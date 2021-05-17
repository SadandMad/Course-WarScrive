using Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels
{
    public class HomeViewModel{
        public IEnumerable<Unit> favUnits { get; set; }
    }
}