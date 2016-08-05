﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageYard.Data.Configuration
{
    class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            Property(one => one.OrderId).HasMaxLength(64).IsVariableLength();
        }
    }
}
