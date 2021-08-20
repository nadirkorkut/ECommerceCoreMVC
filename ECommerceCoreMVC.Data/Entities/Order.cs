﻿using ECommerceCoreMVC.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Entities
{
    public enum OrderStatus
    {
        New,Shipped,Cancelled
    }
    public class Order : BaseEntity
    {
        #region Properties
        public OrderStatus OrderStatus { get; set; }
        public string ShippingNumber { get; set; }

        #endregion

        #region Navigation
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        #endregion

        public override void Build(ModelBuilder builder)
        {
            builder.Entity<Order>(entity => {

                entity
                .HasMany(p => p.OrderItems)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
