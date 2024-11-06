﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public OrderEntity Order { get; set; }

        public ProductEntity Product { get; set; }
    }
    public class OrderProductConfiguration : BaseConfiguration<OrderProductEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.Ignore(x=>x.Id);//ignore base id 
            builder.HasKey("OrderId", "ProductId");//Created composite key
            base.Configure(builder);
        }
    }
}
