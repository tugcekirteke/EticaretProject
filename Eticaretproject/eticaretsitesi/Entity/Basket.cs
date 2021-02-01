using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
    public class Basket:EntityBase
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Ouantity { get; set; }
        public object Quantity { get; set; }
    }
}
