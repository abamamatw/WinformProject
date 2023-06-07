using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformPoject0527
{
    public class ShoppingCartDto
    {
        public int CartID { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
        public int TotalProductPrice { get; set; }

        
    }
}
