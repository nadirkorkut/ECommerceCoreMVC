﻿using ECommerceCoreMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Infrastructure
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public abstract void Build(ModelBuilder builder);
    }
}
