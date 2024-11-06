using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Order.Dtos
{
    public class AddOrderDto
    {
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public List<int> ProductId { get; set; }
    }
}
