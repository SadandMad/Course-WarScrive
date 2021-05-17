using Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Course.Data.Interfaces
{
    public interface IUnitsCategory {
        IEnumerable<Category> getAllCategories { get; }
    }
}
