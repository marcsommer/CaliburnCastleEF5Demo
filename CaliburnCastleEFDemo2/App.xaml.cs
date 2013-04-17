using System.Data.Entity;
using CaliburnCastleEFDemo2.DataLayer;

namespace CaliburnCastleEFDemo2
{
   public partial class App
   {
      Bootstrapper bootstrapper;

      public App()
      {
         bootstrapper = new Bootstrapper();
        // Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeContext>());
      }
   }
}
