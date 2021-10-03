using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PocCQRSMediatorPattern.Api.Controllers;
using PocCQRSMediatorPattern.CoreTest.Mock;
using PocCQRSMediatorPattern.CoreTest.Services;
using PocCQRSMediatorPattern.Library.Model;
using PocCQRSMediatorPattern.Library.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PocCQRSMediatorPattern.UnitTest.Controller
{
    public class EmployeesControllerTest 
    {
        private readonly EmployeesController _controller;
        private IMediator _mediator;
        public EmployeesControllerTest()
        {
            var serviceProvider = DependencyInjection.InitService();
            _mediator = serviceProvider.GetService<IMediator>();
            _controller = new(_mediator);
        }

        [Fact]
        public async Task MediatorTestAsync()
        {
            var teste = await _mediator.Send(new GetEmployeeListQuery());
            teste.Should().NotBeNull();
        }

        [Fact]
        public void Get_SuccessTest()
        {
            //act
            var action = _controller.Get().Result;
            //assert
            action.Should().BeAssignableTo<List<EmployeeModel>>();
        }

        [Fact]
        public void GetById_SuccessTest()
        {
            //act
            var action = _controller.GetById(1).Result;
            //assert
            action.Should().BeAssignableTo<EmployeeModel>();
        }

        [Fact]
        public void Post_SuccessTest()
        {
            //arrange
            var model = EmployeeMock.ModelFake.Generate();
            //act
            var action = _controller.Post(model).Result;
            //assert
            action.Should().BeAssignableTo<EmployeeModel>();
        }
    }
}
