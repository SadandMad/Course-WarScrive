using Course.Data.Interfaces;
using Course.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data.Repository
{
    public class UnitRepository : IAllUnits
    {
        private readonly AppDBContent appDBContent;
        public UnitRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Unit> getUnits => appDBContent.Unit.Include(c => c.Category);

        public IEnumerable<Unit> getFavouriteUnits => appDBContent.Unit.Where(p => p.isFavourite).Include(c => c.Category);

        public Unit getUnit(int UnitID) => appDBContent.Unit.FirstOrDefault(p => p.Id == UnitID);
    }
}
