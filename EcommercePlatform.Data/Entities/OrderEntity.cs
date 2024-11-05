using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Entities
{
    public class OrderEntity:BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }

        //Relational Property
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }

    public class OrderConfiguration:BaseConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);
        }
    }
    
}
