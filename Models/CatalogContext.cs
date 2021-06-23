using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPWebNETCoreAPI.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }
        public DbSet<CatalogItem> CatalogItems { get; set; }
       // public DbSet<CatalogBrand> CatalogBrands { get; set; }
       // public DbSet<CatalogType> CatalogTypes { get; set; }

        // Additional code ...
    }
}
