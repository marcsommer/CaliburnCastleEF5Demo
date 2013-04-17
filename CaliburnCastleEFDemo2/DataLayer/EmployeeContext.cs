using System.Data.Entity;
using CaliburnCastleEFDemo2.Models;

namespace CaliburnCastleEFDemo2.DataLayer
{
   public class EmployeeContext : DbContext
   {
      public DbSet<Employee> Employees { get; set; }
   }
}