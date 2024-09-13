using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiWebCafeteria.Models;

namespace ApiWebCafeteria.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<ApiWebCafeteria.Models.produto> produto { get; set; } = default!;
    }
}
