﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.Order.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<int> ProductIds { get; set; }
    }
}
