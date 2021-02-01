using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
  public class Odeme:EntityBase
        //orderpayment tablosu
    {
        public int OrderID { get; set; }
         
        public _OrderType OrderType { get; set; }
        public decimal fiyat { get; set; }
        public string Bank { get; set; }
        public int ProductID { get; set; }
        public object Quantity { get; set; }
    }
    public enum _OrderType
    {
        Havale=0,
        KrediKartı=1

        
    }
}
