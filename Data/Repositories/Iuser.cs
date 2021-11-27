using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUser:IDisposable
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userId);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool DeleteUser(int userId);
        void Save();
    }
}
