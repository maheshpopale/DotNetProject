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
        public Product getProductById(int id)
        {
           return context.Products.FirstOrDefault(product => product.Id == id);
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

        }
        public void UpdateProductlist(Product productlist)
        {
            productlist.CreatedAt = DateTime.Now;
            productlist.UpdatedAt = DateTime.Now;
            context.Entry<Product>(productlist).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        internal Product getProductByCategory(int id)
        {
            return context.Products.FirstOrDefault(product => product.CategoryId== id);
        }
    }
}
