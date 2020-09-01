using Microsoft.EntityFrameworkCore;
using  FreelanceApp.API.Models;

namespace FreelanceApp.API.Data
{
    public class DataContext : DbContext
    {
           public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
              
            }


           public  DbSet<Value> MyProperty{ get; set; }

    }
}