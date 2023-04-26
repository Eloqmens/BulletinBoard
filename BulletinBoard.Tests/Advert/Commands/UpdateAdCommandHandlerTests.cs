using BulletinBoard.Application.BulletinBoard.Advert.Commands.UpdateCommand;
using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BulletinBoard.Tests.Advert.Commands
{
    public class UpdateAdCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateAdCommandHandler_Succes()
        {
            // Arrange
            var handler = new UpdateAdCommandHandler(Context);
            var updateName = "update Name produtct";
            var updateDescription = "update Description";
            decimal price = 4151251;

            // Act
            await handler.Handle(new UpdateAdCommand
            {
                Id = AdvertContextFactory.AdvertIdForUpdate,
                UserId = AdvertContextFactory.UserBId,
                Description = updateDescription,
                Name = updateName,
                Price = price,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Ads.SingleOrDefaultAsync(ad => 
            ad.Id == AdvertContextFactory.AdvertIdForUpdate
            && ad.Name == updateName
            && ad.Description == updateDescription
            && ad.Price == price));
        }

        [Fact]
        public async Task UpdateAdCommmandHandler_FailOnWrondId()
        {
            // Arrange
            var handler = new UpdateAdCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateAdCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = AdvertContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
        

        [Fact]
        public async Task UpdateAdCommmandHandler_FailOnWrondUserId()
        {
            // Arrange
            var handler = new UpdateAdCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateAdCommand
                    {
                        Id = AdvertContextFactory.AdvertIdForUpdate,
                        UserId = AdvertContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
