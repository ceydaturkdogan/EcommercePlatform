using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Entities
{
    public class ProductEntity:BaseEntity
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        //Relational Property
        public ICollection<OrderEntity> Order { get; set; }
    }
}
