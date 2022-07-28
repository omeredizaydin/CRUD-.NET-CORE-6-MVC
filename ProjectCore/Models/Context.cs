using Microsoft.EntityFrameworkCore;

namespace ProjectCore.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer()
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CJ5M07K\SQLEXPRESS;Database=CompanyDB;integrated security=True;");

        }
        public DbSet<Birim> Birims{ get; set; }
        public DbSet<Personel> Personels{ get; set; }
        public DbSet<Admin> Admins{ get; set; }
    }
}
