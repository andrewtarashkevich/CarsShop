using CarsShop.DAL.EF;
using CarsShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private UserContext db;
        public UserRepository(UserContext db)
        {
            this.db = db;
        }
    
        public void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
            db.SaveChanges();
        }        


        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User user)
        {
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
