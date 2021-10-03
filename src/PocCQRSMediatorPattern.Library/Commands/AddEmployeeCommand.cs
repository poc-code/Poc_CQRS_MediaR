using MediatR;
using PocCQRSMediatorPattern.Library.Model;

namespace PocCQRSMediatorPattern.Library.Commands
{
    public record AddEmployeeCommand(string firstName, string lastName) 
        : IRequest<EmployeeModel>{ }
}
