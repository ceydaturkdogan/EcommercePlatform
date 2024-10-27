﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Entities
{
    public class UserEntity:BaseEntity
    {
        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }


    }
}
