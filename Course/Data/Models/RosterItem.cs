using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data.Models {
    public class RosterItem {
        public int Id { get; set; }
        public Unit unit { get; set; }
        public string rosterId { get; set; }
    }
}
