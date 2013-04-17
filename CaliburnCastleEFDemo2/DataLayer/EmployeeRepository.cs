using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using CaliburnCastleEFDemo2.Models;

namespace CaliburnCastleEFDemo2.DataLayer
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private DbContext _context = new EmployeeContext();

      public void AddNewEmployee(Employee newEmployee)
      {
         _context.Entry(newEmployee).State = EntityState.Added;
         _context.Entry(newEmployee.Occupation).State = EntityState.Unchanged;
         _context.SaveChanges();
      }

      public void AddNewOccupation(Occupation newOccupation)
      {
         _context.Entry(newOccupation).State = EntityState.Added;
         _context.SaveChanges();
      }

      public IEnumerable<Occupation> getAllOccupations()
      {
         return _context.Set<Occupation>();
      }
   }
}