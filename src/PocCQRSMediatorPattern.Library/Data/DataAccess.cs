using AutoBogus;
using PocCQRSMediatorPattern.Library.Interface;
using PocCQRSMediatorPattern.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace PocCQRSMediatorPattern.Library.Data
{
    public class DataAccess : IDataAccess
    {
        private List<EmployeeModel> _employess = new (); //C# 9 sintax
        public DataAccess()
        {
            _employess.AddRange(
                new AutoFaker<EmployeeModel>()
                .RuleFor(x => x.Id, fake => (uint) fake.IndexFaker + 1)
                .RuleFor(x => x.FistName, fake => fake.Person.FirstName)
                .RuleFor(x => x.LastName, fake => fake.Person.LastName)
                .Generate(2));
        }
        public List<EmployeeModel> GetEmployees()
        {
            return _employess;
        }

        public EmployeeModel AddEmployee(string firstName, string lastName)
        {
            EmployeeModel newEmployee = new() { FistName = firstName, LastName = lastName };
            newEmployee.Id = _employess.Max(x => x.Id) +1;
            return newEmployee;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return _employess.FirstOrDefault(x => x.Id == id);
        }
    }
}
