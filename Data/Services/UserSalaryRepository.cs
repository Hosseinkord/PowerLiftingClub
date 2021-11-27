using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserSalaryRepository:IUserSalary
    {
        private ClubContext db;

        public UserSalaryRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<UserSalary> GetAllUserSalary()
        {
            return db.UserSalaries;
        }

        public UserSalary GetUserSalaryById(int userSalaryId)
        {
            return db.UserSalaries.Find(userSalaryId);
        }

        public bool InsertUserSalary(UserSalary userSalary)
        {
            try
            {
                db.UserSalaries.Add(userSalary);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateUserSalary(UserSalary userSalary)
        {
            try
            {
                db.Entry(userSalary).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteUserSalary(UserSalary userSalary)
        {
            try
            {
                db.Entry(userSalary).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteUserSalary(int userSalaryId)
        {
            try
            {
                var userSalary = GetUserSalaryById(userSalaryId);
                DeleteUserSalary(userSalary);
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
