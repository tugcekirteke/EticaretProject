using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
      public class BasketDetail:EntityBase
        
        //orderproduct tablosu 
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
