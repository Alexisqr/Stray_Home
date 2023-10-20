using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Domain.Entities
{
    public class UserShopItem
    {
        public int UserID { get; set; }

        public User User { get; set; } 
        public int ShopItemID { get; set; }
        public ShopItem ShopItem { get; set; } 
        public DateTime OrderDate { get; set; }
    }
}
