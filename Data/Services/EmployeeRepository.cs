using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class EmployeeRepository:IEmployee
    {
        private ClubContext db;

        public EmployeeRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return db.Employees.Find(employeeId);
        }

        public bool InsertEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var employee = GetEmployeeById(employeeId);
                DeleteEmployee(employee);
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
