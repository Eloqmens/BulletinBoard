using BulletinBoard.Application.Interfaces;
using BulletinBoard.Domain;
using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Commands.CreateCommand
{
    public class CreateAdCommandHandler
        : IRequestHandler<CreateAdCommand, Guid> 
    {
        private readonly IBulletinBoardDbContext _dbContext;
        public CreateAdCommandHandler(IBulletinBoardDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var ad = new Ad
            {
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Ads.AddAsync(ad, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ad.Id;
        }
    }
}
