using EmpManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpManagement.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext() : base("EmployeeDbContext")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}