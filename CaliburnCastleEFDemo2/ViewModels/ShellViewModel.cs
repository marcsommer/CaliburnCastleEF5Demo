using Caliburn.Micro;
using CaliburnCastleEFDemo2.DataLayer;
using CaliburnCastleEFDemo2.Models;

namespace CaliburnCastleEFDemo2.ViewModels
{
   public class ShellViewModel : Screen
   {
      private string _name;
      private int _age;
      private Occupation _selectedOccupation;
      private readonly IEmployeeRepository _employeeRepository;
      private string _jobTitle;
      private BindableCollection<Occupation> _occupations;

      public ShellViewModel(IEmployeeRepository employeeRepository)
      {
         _employeeRepository = employeeRepository;
         var allOccupations = _employeeRepository.getAllOccupations();
         _occupations = new BindableCollection<Occupation>(allOccupations);
      }

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public int Age
      {
         get { return _age; }
         set { _age = value; }
      }

      public Occupation SelectedOccupation
      {
         get { return _selectedOccupation; }
         set
         {
            if (Equals(value, _selectedOccupation)) return;
            _selectedOccupation = value;
            NotifyOfPropertyChange(() => SelectedOccupation);
         }
      }

      public BindableCollection<Occupation> Occupations
      {
         get { return _occupations; }
         set { _occupations = value; }
      }

      public void AddNewPerson()
      {
         Employee newEmployee = new Employee
                                   {
                                      Age = _age,
                                      Name = _name,
                                      Occupation = _selectedOccupation
                                   };
         _employeeRepository.AddNewEmployee(newEmployee);
      }

      public string JobTitle
      {
         get { return _jobTitle; }
         set { _jobTitle = value; }
      }

      public void AddNewOccupation()
      {
         Occupation newOccupation = new Occupation
                                       {
                                          Name = _jobTitle
                                       };
         _employeeRepository.AddNewOccupation(newOccupation);

         // when a new occupation is added, need to update the combobox
         var occupations = _employeeRepository.getAllOccupations();
         Occupations.Clear();
         Occupations.AddRange(occupations);
      }
   }
}
