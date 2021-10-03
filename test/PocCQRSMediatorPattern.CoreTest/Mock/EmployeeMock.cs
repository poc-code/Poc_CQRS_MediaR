using AutoBogus;
using Bogus;
using PocCQRSMediatorPattern.Library.Model;

namespace PocCQRSMediatorPattern.CoreTest.Mock
{
    public static class EmployeeMock
    {
        public static Faker<EmployeeModel> ModelFake => new AutoFaker<EmployeeModel>()
            .RuleFor(x => x.FistName, faker => faker.Person.FirstName)
            .RuleFor(x => x.LastName, faker => faker.Person.LastName);
    }
}
