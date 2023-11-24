using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class UserShopItem
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid ShopItemID { get; set; }
        public ShopItem ShopItem { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
