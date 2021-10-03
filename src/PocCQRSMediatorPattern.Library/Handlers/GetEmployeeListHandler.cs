using MediatR;
using PocCQRSMediatorPattern.Library.Interface;
using PocCQRSMediatorPattern.Library.Model;
using PocCQRSMediatorPattern.Library.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PocCQRSMediatorPattern.Library.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
    {
        private readonly IDataAccess _dataAccess;

        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployees());
        }
    }
}
