using PocCQRSMediatorPattern.Library.Model;
using System.Collections.Generic;

namespace PocCQRSMediatorPattern.Library.Interface
{
    public interface IDataAccess
    {
        List<EmployeeModel> GetEmployees();
        EmployeeModel GetEmployeeById(int id);
        EmployeeModel AddEmployee(string firtName, string lastName);
    }
}
