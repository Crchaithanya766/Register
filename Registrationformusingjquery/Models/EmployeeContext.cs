using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Registrationformusingjquery.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base("Mydb")
        { }
        public DbSet<EmployeeReg> employeeRegs { get; set; }
    }
}