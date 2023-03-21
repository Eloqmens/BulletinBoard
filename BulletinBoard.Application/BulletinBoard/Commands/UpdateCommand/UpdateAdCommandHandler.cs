using Microsoft.EntityFrameworkCore;
using BulletinBoard.Application.Interfaces;
using MediatR;
using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Domain;

namespace BulletinBoard.Application.BulletinBoard.Commands.UpdateCommand
{
    public class UpdateAdCommandHandler
        : IRequestHandler<UpdateAdCommand, Unit>
    {

        private readonly IBulletinBoardDbContext _dbContext;
        public UpdateAdCommandHandler(IBulletinBoardDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Ads.FirstOrDefaultAsync(x =>
                x.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }


}
