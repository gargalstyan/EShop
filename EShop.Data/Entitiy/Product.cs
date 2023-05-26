using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Entitiy
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? Count { get; set; }
        [Browsable(false)]
        public Shop? Shop { get; set; }

        [ForeignKey("Shop")]
        public int? ShopId { get; set; }
    }
}
