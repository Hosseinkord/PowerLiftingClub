using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserSalary:IDisposable
    {
        IEnumerable<UserSalary> GetAllUserSalary();
        UserSalary GetUserSalaryById(int userSalaryId);
        bool InsertUserSalary(UserSalary userSalary);
        bool UpdateUserSalary(UserSalary userSalary);
        bool DeleteUserSalary(UserSalary userSalary);
        bool DeleteUserSalary(int userSalaryId);
        void Save();
    }
}
