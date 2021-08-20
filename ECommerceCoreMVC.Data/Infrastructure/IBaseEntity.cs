using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceCoreMVC.Data.Infrastructure
{
    public interface IBaseEntity
    {
        void Build(ModelBuilder builder);
    }
}
