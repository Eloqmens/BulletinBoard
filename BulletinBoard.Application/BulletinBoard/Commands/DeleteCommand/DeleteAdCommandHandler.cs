using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Domain;
using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Commands.DeleteCommand
{
    public class DeleteAdCommandHandler
        : IRequestHandler<DeleteAdCommand, Unit>
    {
        private readonly IBulletinBoardDbContext _dbContext;

        public DeleteAdCommandHandler(IBulletinBoardDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteAdCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Ads
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            _dbContext.Ads.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
