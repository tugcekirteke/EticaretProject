using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
    public class Category : EntityBase
    {

        public int parentID { get; set; } = 0;
       
        public String name { get; set; }
        public bool IsActive { get; set; }

    }
}
