using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public interface IEmployeePay:IDisposable
    {
        IEnumerable<EmployeePay> GetAllEmployeePay();
        EmployeePay GetEmployeePayById(int employeePayId);
        bool InsertEmployeePay(EmployeePay employeePay);
        bool UpdateEmployeePay(EmployeePay employeePay);
        bool DeleteEmployeePay(EmployeePay employeePay);
        bool DeleteEmployeePay(int employeePayId);
        void Save();
    }
}
