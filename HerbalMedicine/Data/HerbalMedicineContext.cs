using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerbalMedicine.Models;

namespace HerbalMedicine.Data
{
    public class HerbalMedicineContext : DbContext
    {
        public HerbalMedicineContext (DbContextOptions<HerbalMedicineContext> options)
            : base(options)
        {
        }

        public DbSet<HerbalMedicine.Models.Herbal>? Herbal { get; set; }
    }
}
