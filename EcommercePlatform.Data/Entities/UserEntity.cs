using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Entities
{
    public class UserEntity:BaseEntity
    {
        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        //public string? PhoneNumber { get; set; }
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public class UserConfiguration : BaseConfiguration<UserEntity>
        {
            public override void Configure(EntityTypeBuilder<UserEntity> builder)
            {
                builder.Property(x => x.FirstName).IsRequired();
                builder.Property(builder => builder.LastName).IsRequired();
                builder.Property(builder=> builder.Email).IsRequired();

                base.Configure(builder);
            }
        }
    }
}
