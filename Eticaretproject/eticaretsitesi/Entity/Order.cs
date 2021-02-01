using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
    public class Order:EntityBase//order
    {
        public int UserID { get; set; }

        public User User { get; set; }

        public int UserAddressID { get; set; }
        public UserAddress UserAddress { get; set; }
         public int StatusID { get; set; }
        public Status Status { get; set; }
        public decimal ToplamUrunFiyat { get; set; }
        public decimal ToplamVergi { get; set; }
        public decimal ToplamIndirim { get; set; }
        public decimal TopplamFiyat { get; set; }
        public virtual List<Odeme> Odemes { get; set; }
        public virtual List<BasketDetail> BasketDetail { get; set; }



    }
}
