using BulletinBoard.Application.BulletinBoard.Advert.Commands.CreateCommand;
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
    public class CreateAdCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateAdCommandHandlerTests_Succes()
        {
            // Arange 
            var handler = new CreateAdCommandHandler(Context);
            var adName = "ad name";
            var descript = "desciption info";
            decimal price = 2415235;

            // Act 
            var AdId = await handler.Handle(
                new CreateAdCommand
                {
                    Name = adName,
                    Price = price,
                    Description = descript,
                    UserId = AdvertContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert 
            Assert.NotNull(
                await Context.Ads.SingleOrDefaultAsync(ad => ad.Id == AdId
                && ad.Name == adName
                && ad.Description == descript
                && ad.Price == price));
        }
    }
}
