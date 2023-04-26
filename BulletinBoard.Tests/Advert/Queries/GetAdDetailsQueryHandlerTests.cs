using AutoMapper;
using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdDetails;
using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdList;
using BulletinBoard.Persistence;
using BulletinBoard.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BulletinBoard.Tests.Advert.Queries
{
    [Collection("QueryCollection")]
    public class GetAdDetailsQueryHandlerTests
    {
        private readonly BulletinBoardDbContext Context;
        private readonly IMapper Mapper;
        public GetAdDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetAdDetailsQueryHandler_Success() 
        {
            // Arrange
            var handler = new GetAdDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetAdDetailsQuery
                {
                    UserId = AdvertContextFactory.UserAId,
                    Id = Guid.Parse("86C61580-3EC6-4B89-B400-1A879F4280E8")                   
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AdDetailsVm>();
            result.Name.ShouldBe("Name Sales");
        }
    }
}
