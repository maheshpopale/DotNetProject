using MyntraDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyntraClone.Models
{
    public class UserRepository
    {
        dev_MyntradbContext context = new dev_MyntradbContext();

        public IEnumerable<User> getUser()
        {
            var users = context.Users.ToList();
            return users;
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

        }
        public User checkUserAvailable(User user1)
        {
            return context.Users.FirstOrDefault(user => user.Email == user1.Email && user.Password==user1.Password);
        }
    }
}
