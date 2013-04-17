namespace CaliburnCastleEFDemo2.Models
{
   public class Employee : IEntity
   {
      public string Name { get; set; }
      public int Age { get; set; }
      public virtual Occupation Occupation { get; set; }
      public int ID { get; set; }
   }
}