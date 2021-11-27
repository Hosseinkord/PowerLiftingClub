using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClubContext:DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubToolsList> ClubToolsLists { get; set; }

        public DbSet<Coach> Coaches{ get; set; }
        public DbSet<CoachPay> CoachPays { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<EmployeePay> EmployeePays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSalary> UserSalaries { get; set; }

    }
}
