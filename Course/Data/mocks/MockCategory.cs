using Course.Data.Interfaces;
using Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data.mocks
{
    public class MockCategory : IUnitsCategory
    {
        public IEnumerable<Category> getAllCategories {
            get {
                return new List<Category> {
                    new Category { Name = "HQ", Desc = "Командующие персонажи вашей армии" },
                    new Category { Name = "Troops", Desc = "Ваши основные войска" },
                    new Category { Name = "Elites", Desc = "Особые подразделения" },
                    new Category { Name = "Fast Attack", Desc = "Gonna go FAST" },
                    new Category { Name = "Heavy Support", Desc = "KILL THEM ALL!" }
                };
            }
        }
        
    }
}