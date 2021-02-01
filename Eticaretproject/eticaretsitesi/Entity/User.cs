using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi.Entity
{
    public class User : EntityBase
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string password { get; set; }

        public string TCKN { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public virtual IEnumerable<UserAddress> UserAddresses { get; set; }

    }
}
