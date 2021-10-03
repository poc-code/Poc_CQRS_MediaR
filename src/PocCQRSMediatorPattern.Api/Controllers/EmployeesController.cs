using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocCQRSMediatorPattern.Library.Commands;
using PocCQRSMediatorPattern.Library.Model;
using PocCQRSMediatorPattern.Library.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocCQRSMediatorPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EmployeeModel>> Get()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }

        [HttpGet("{id}")]
        public async Task<EmployeeModel> GetById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        [HttpPost]
        public async Task<EmployeeModel> Post([FromBody] EmployeeModel model)
        {
            return await _mediator.Send(new AddEmployeeCommand(model.FistName, model.LastName));
        }
    }
}
