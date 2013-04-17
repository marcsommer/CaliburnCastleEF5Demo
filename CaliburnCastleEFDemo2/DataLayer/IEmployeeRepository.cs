using System.Collections.Generic;
using CaliburnCastleEFDemo2.Models;

namespace CaliburnCastleEFDemo2.DataLayer
{
   public interface IEmployeeRepository
   {
      void AddNewEmployee(Employee newEmployee);
      void AddNewOccupation(Occupation newOccupation);
      IEnumerable<Occupation> getAllOccupations();
   }
}