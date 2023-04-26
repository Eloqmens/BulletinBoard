using BulletinBoard.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly BulletinBoardDbContext Context;

        public TestCommandBase()
        {
            Context = AdvertContextFactory.Create();
        }

        public void Dispose()
        {
            AdvertContextFactory.Destroy(Context);
        }
    }
}
