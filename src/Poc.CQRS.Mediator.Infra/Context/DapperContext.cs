using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Wiz.WimoChecklist.Infra.Context
{
    [ExcludeFromCodeCoverage]
    public class DapperContext : IDisposable
    {
        private readonly IDbConnection _conn;
        private bool disposed = false;

        public DapperContext(IDbConnection conn)
        {
            _conn = conn;
        }

        public IDbConnection DapperConnection
        {
            get
            {
                return _conn;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _conn.Dispose();
                }

                this.disposed = true;
            }
        }
    }

}
