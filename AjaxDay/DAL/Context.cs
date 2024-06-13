using Microsoft.EntityFrameworkCore;

namespace AjaxDay.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R7AR1ND;initial Catalog=AjaxDb;integrated Security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
