namespace CaliburnCastleEFDemo2.Models
{
   public class Occupation : IEntity
   {
      public string Name { get; set; }
      public int ID { get; set; }

      public override string ToString()
      {
         return Name;
      }
   }
}