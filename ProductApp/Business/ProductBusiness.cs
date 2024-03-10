using Data.Data;
using Data.Model;

namespace Business
{
    public class ProductBusiness
    {
        private ProductContext context;
        public List<Product> GetAll()
        {
            using (context = new ProductContext()) 
            {
                return context.Products.ToList();
            }
        }
        public Product Get(int id)
        {
            using (context = new ProductContext())
            {
                return context.Products.Find(id);
            }
        }
        public void Add(Product product)
        {
            using(context = new ProductContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (context = new ProductContext())
            {
                var item = context.Products.Find(product.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(product);
                    context.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using(context =new ProductContext())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

    }
}
