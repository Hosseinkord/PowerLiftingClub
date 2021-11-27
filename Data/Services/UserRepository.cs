using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public  class UserRepository:IUser
    {
        private ClubContext db;

        public UserRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<User> GetAllUser()
        {
            return db.Users;
        }

        public User GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public bool InsertUser(User user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = GetUserById(userId);
                DeleteUser(user);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
