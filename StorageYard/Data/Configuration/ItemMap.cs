﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageYard.Data.Configuration
{
    class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            Property(one => one.Name).HasMaxLength(128).IsVariableLength();
            Property(one => one.Description).HasMaxLength(1024).IsVariableLength().IsOptional();

            HasMany<Order>(one => one.Orders).WithMany(one => one.Items).Map(cs =>
            {
                cs.MapLeftKey("ItemId");
                cs.MapRightKey("OrderId");
                cs.ToTable("ItemOrder");
            });
            HasRequired(one => one.Menu).WithMany(one => one.Items).HasForeignKey(one => one.MenuId);
        }
    }
}
