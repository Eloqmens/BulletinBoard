using BulletinBoard.Domain;
using BulletinBoard.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Tests.Common
{
    public class AdvertContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid AdvertIdForDelete = Guid.NewGuid();
        public static Guid AdvertIdForUpdate = Guid.NewGuid();

        public static BulletinBoardDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BulletinBoardDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new BulletinBoardDbContext(options);
            context.Database.EnsureCreated();
            context.Ads.AddRange(new Domain.Ad
            {
                CreationDate = DateTime.Today,
                Description = "Details description",
                Price = 2414,
                Id = Guid.Parse("86C61580-3EC6-4B89-B400-1A879F4280E8"),
                UserId = UserAId,
                Name = "Name Sales",
            },
            new Ad
            {
                CreationDate= DateTime.Today,
                Description = "Details description 2",
                Price = 5215,
                Id = Guid.Parse("CBC732A2-D223-4124-A4E9-D341A74AC7BD"),
                UserId = UserBId,
                Name = "Name Sales 2"
            },
            new Ad
            {
                CreationDate= DateTime.Today,
                Description = "Details description 3",
                Price = 1215,
                Id = AdvertIdForDelete,
                UserId = UserAId,
                Name = "Name Sales 3"
            },
            new Ad
            {
                 CreationDate= DateTime.Today,
                Description = "Details description 4",
                Price = 125235,
                Id = AdvertIdForUpdate,
                UserId = UserBId,
                Name = "Name Sales 4"
            }
            
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(BulletinBoardDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
