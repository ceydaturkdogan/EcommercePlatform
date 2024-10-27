using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Entities
{
    public class OrderProductEntity:BaseEntity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        //Relational Property
        public ICollection<OrderEntity> Orders { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }

}
