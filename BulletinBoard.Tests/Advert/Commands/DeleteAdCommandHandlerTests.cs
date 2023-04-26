using BulletinBoard.Application.BulletinBoard.Advert.Commands.CreateCommand;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.DeleteCommand;
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
    public class DeleteAdCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteAdCommandHandler_Success()
        {
            // Arange 
            var handler = new DeleteAdCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteAdCommand
            {
                Id = AdvertContextFactory.AdvertIdForDelete,
                UserId = AdvertContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Ads.SingleOrDefaultAsync(ad =>
            ad.Id == AdvertContextFactory.AdvertIdForDelete));
        }

        [Fact]
        public async Task DeleteAdCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteAdCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteAdCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = AdvertContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteAdCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteAdCommandHandler(Context);
            var createHandler = new CreateAdCommandHandler(Context);
            var AdId = await createHandler.Handle(
                new CreateAdCommand
                {
                    Name = "Ad Name for delete",
                    Description= "Description for delete",
                    Price = 1531,
                    UserId = AdvertContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteAdCommand
                    {
                        Id = AdId,
                        UserId = AdvertContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
