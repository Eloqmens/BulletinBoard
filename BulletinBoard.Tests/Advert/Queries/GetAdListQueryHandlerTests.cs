using AutoMapper;
using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdList;
using BulletinBoard.Application.BulletinBoard.Querries.GetAdList;
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
    public class GetAdListQueryHandlerTests
    {
        private readonly BulletinBoardDbContext Context;
        private readonly IMapper Mapper;

        public GetAdListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAdListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAdListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetAdListQuery
                {
                    UserId = AdvertContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AdListVm>();
            result.Ads.Count.ShouldBe(2);
        }
    }
}
