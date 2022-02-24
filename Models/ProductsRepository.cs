using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyntraClone.Models
{
    public class ProductsRepository
    {
        dev_MyntradbContext context = new dev_MyntradbContext();
        
        public IEnumerable<Product> getProducts()
        {
            var products = context.Products.ToList();
            return products;
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

        }
        public void UpdateProduct(Product product)
        {
            context.Entry<Product>(product).State =EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
