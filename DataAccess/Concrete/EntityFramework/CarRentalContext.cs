using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// Context: Db tabloları ile proje classlarını bağlamak.
    /// </summary>
    public class CarRentalContext:DbContext
    {
        /// <summary>
        /// projenin hangi db ile ilişkilendirileceğinin bulunduğu yer.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarRentalDb;Trusted_Connection=true");
        }

        //Added Db tables
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
