using AutoMapper;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BulletinBoard.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public BulletinBoardDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = AdvertContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IBulletinBoardDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            AdvertContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
