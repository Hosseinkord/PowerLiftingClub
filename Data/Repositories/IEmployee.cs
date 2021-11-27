using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEmployee:IDisposable
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int employeeId);
        bool InsertEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        void Save();
    }
}
