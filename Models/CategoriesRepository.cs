using Microsoft.EntityFrameworkCore;
using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Models
{
    public class CategoriesRepository
    {
        dev_MyntradbContext context = new dev_MyntradbContext();
        public IEnumerable<Category> getCategories()
        {
            var categories = context.Categories.ToList();
            return categories;
        }
        public Category getCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(category => category.Id == id);
        }
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

        }
        public void UpdateCategory(Category category)
        {
            context.Entry<Category>(category).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            var category = context.Categories.FirstOrDefault(p => p.Id == id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
