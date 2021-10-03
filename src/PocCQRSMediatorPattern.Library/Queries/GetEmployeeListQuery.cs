using MediatR;
using PocCQRSMediatorPattern.Library.Model;
using System.Collections.Generic;

namespace PocCQRSMediatorPattern.Library.Queries
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeModel>>{ }
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeModel> { }
}
