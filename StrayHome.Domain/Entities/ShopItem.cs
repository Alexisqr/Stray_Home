using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class ShopItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Photos { get; set; }
        public int StockQuantity { get; set; }
    }
}
