using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
    public class Product:EntityBase
    {
        public string Adi { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public string marka { get; set;}

        public string model { get; set; }

        public string imageUrl { get; set; }

        public string Açıklama { get; set; }
        public decimal fiyat { get; set; }
        public decimal vergi { get; set; }
        public int stok { get; set; }
        public decimal indirim { get; set; }
        public bool IsActive { get; set; }
    }
}
