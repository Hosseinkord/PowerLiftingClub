using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeePayRepository:IEmployeePay
    {
        private ClubContext db;

        public EmployeePayRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<EmployeePay> GetAllEmployeePay()
        {
            return db.EmployeePays;
        }

        public EmployeePay GetEmployeePayById(int employeePayId)
        {
            return db.EmployeePays.Find(employeePayId);
        }

        public bool InsertEmployeePay(EmployeePay employeePay)
        {
            try
            {
                db.EmployeePays.Add(employeePay);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateEmployeePay(EmployeePay employeePay)
        {
            try
            {
                db.Entry(employeePay).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteEmployeePay(EmployeePay employeePay)
        {
            try
            {
                db.Entry(employeePay).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteEmployeePay(int employeePayId)
        {
            try
            {
                var employeePay = GetEmployeePayById(employeePayId);
                DeleteEmployeePay(employeePay);
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
