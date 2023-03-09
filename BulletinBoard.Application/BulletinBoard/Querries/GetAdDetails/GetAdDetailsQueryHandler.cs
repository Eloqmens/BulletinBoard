using AutoMapper;
using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Application.BulletinBoard.Querries.GetAdDetails
{
    public class GetAdDetailsQueryHandler :
        IRequestHandler<GetAdDetailsQuery, AdDetailsVm>
    {
        private readonly IBulletinBoardDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAdDetailsQueryHandler(IBulletinBoardDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AdDetailsVm> Handle(GetAdDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Ads
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Ad), request.Id);
            }

            return _mapper.Map<AdDetailsVm>(entity);
        }

    }
}
