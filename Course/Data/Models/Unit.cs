using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string shortDesk { get; set; }
        public string longDesk { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavourite { get; set; }
        public int available { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}