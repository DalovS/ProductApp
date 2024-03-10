using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ProductContext : DbContext
    {
       public DbSet<Product> Products { get; set; }
        public ProductContext(): base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True") 
        {

        }
    }
}
