using MediatR;
using PocCQRSMediatorPattern.Library.Interface;
using PocCQRSMediatorPattern.Library.Model;
using PocCQRSMediatorPattern.Library.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PocCQRSMediatorPattern.Library.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeByIdHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployeeById(request.Id));
        }
    }
}
