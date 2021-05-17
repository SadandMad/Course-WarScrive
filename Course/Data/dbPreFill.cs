using Course.Data.mocks;
using Course.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data
{
    public class dbPreFill
    {
        public static void Initial(AppDBContent content) {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Unit.Any())
            {
                content.AddRange(
                    new Unit
                    {
                        Name = "Primaris Captain",
                        shortDesk = "Первый парень на селе",
                        longDesk = "Капитаны Космодесанта – одновременно превосходные воители и одарённые полководцы, командующие в бою ротами Адептус Астартес.",
                        img = "/img/99120101179_PrimarisCaptain01.webp",
                        price = 5,
                        isFavourite = true,
                        available = 1,
                        Category = Categories["HQ"]
                    },
                    new Unit
                    {
                        Name = "Intercessor Squad",
                        shortDesk = "Стоим-стреляем",
                        longDesk = "Заступники — это ядро любой ударной группировки космодесантников-примарис.",
                        img = "/img/99120101190_PrimarisIntercessors01.webp",
                        price = 5,
                        isFavourite = true,
                        available = 3,
                        Category = Categories["Troops"]
                    },
                    new Unit
                    {
                        Name = "Hellblaster Squad",
                        shortDesk = "Главное - не кинуть кол",
                        longDesk = "Изничтожители — отряды, составленные из превосходных стрелков, обеспечивающие группировкам космодесантников-примарис опустошительную огневую мощь на средней дистанции.",
                        img = "/img/99120101189_PrimarisHellblasters01.webp",
                        price = 8,
                        isFavourite = true,
                        available = 3,
                        Category = Categories["Heavy Support"]
                    },
                    new Unit
                    {
                        Name = "Deathwing Terminators",
                        shortDesk = "А ты часом не Падший?",
                        longDesk = "Отделения терминаторов – неукротимые воины, разносящие врага на части шквальным огнём штормболтеров.",
                        img = "/img/99120101096_DeathwingTerminators01.jpg",
                        price = 9,
                        isFavourite = false,
                        available = 0,
                        Category = Categories["Elites"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get {
                if(category == null) {
                    var list = new Category[] {
                        new Category { Name = "HQ", Desc = "Командующие персонажи вашей армии" },
                        new Category { Name = "Troops", Desc = "Ваши основные войска" },
                        new Category { Name = "Elites", Desc = "Особые подразделения" },
                        new Category { Name = "Fast Attack", Desc = "Gonna go FAST" },
                        new Category { Name = "Heavy Support", Desc = "KILL THEM ALL!" }
                    };
                    
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.Name, el);
                }
                return category;
            }
        }
    }
}