using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Dapper;
using Poc.CQRS.Mediator.Infra.Context;
using Poc.CQRS.Mediator.Infra.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Wiz.WimoChecklist.Infra.Context;

namespace Poc.CQRS.Mediator.Core.Tests.Helper
{
    public class BaseRepositoryTest<T> where T : class
    {
        private readonly DbContextOptions<EntityContext> _entityOptions;
        private Mock<IDbConnection> _conn;
        private readonly EntityContext _entityContext;
        private readonly DapperContext _dapperContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly T _one;
        private readonly IEnumerable<T> _allData;

        public BaseRepositoryTest(IEnumerable<T> data)
        {
            _allData = data;
            _one = data.FirstOrDefault();

            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "DB")]).Returns("mock value");

            ConfigurationMock = new Mock<IConfiguration>();
            ConfigurationMock.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings")))
                .Returns(mockConfSection.Object); ;

            _conn = new Mock<IDbConnection>();
            _conn.SetupDapperAsync(c => c.QueryAsync<T>(
                It.IsAny<string>(),
                null,
                null,
                null,
                null)).ReturnsAsync(data);

            //_conn.SetupDapper(x => x.QueryFirstOrDefault<T>(It.IsAny<string>(), null, null, null, null))
            //    .Returns(_one);

            /*Connection.SetupDapper(x => x.Query<T>(It.IsAny<string>(),null,null,true,null,null))
             .Returns(AllData);*/

            _entityOptions = new DbContextOptionsBuilder<EntityContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .EnableSensitiveDataLogging()
               .Options;

            _entityContext = new EntityContext(_entityOptions);
            _dapperContext = new DapperContext(_conn.Object);
            _unitOfWork = new UnitOfWork(_entityContext);

        }

        public EntityContext EntityContextMock
        {
            get => _entityContext;
        }

        public DbContextOptions<EntityContext> EntityOptions => _entityOptions;

        public DapperContext DapperContextMock
        {
            get => _dapperContext;
        }

        public UnitOfWork UnitOfWorkMock
        {
            get => _unitOfWork;
        }

        public Mock<IConfiguration> ConfigurationMock { get; }

        public T FirstData
        {
            get => _one;
        }

        public IEnumerable<T> AllData
        {
            get => _allData;
        }

        public Mock<IDbConnection> Connection
        {
            get => _conn;
            set
            {
                _conn = value;
            }
        }
    }

}