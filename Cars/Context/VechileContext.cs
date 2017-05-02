using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cars.Context
{
    public class VechileContext : DbContext
    {
        public DbSet<VechileMake> VechileMakes { get; set; }
        public DbSet<VechileModel> VechileModels { get; set; }
    }
}