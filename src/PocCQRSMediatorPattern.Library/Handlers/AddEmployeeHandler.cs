using MediatR;
using PocCQRSMediatorPattern.Library.Commands;
using PocCQRSMediatorPattern.Library.Interface;
using PocCQRSMediatorPattern.Library.Model;
using System.Threading;
using System.Threading.Tasks;

namespace PocCQRSMediatorPattern.Library.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public AddEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<EmployeeModel> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddEmployee(request.firstName, request.lastName));
        }
    }
}
