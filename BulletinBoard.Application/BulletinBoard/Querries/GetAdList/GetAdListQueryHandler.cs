using AutoMapper;
using AutoMapper.QueryableExtensions;
using BulletinBoard.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Application.BulletinBoard.Querries.GetAdList
{
    public class GetAdListQueryHandler
        : IRequestHandler<GetAdListQuery, AdListVm>
    {
        private readonly IBulletinBoardDbContext _context;
        private readonly IMapper _mapper;

        public GetAdListQueryHandler(IBulletinBoardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AdListVm> Handle(GetAdListQuery request, CancellationToken cancellationToken)
        {
            var adQuery = await _context.Ads
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<AdLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AdListVm { Ads = adQuery };
        }
    }
}
