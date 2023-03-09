using BulletinBoard.Application.Interfaces;
using BulletinBoard.Domain;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Application.BulletinBoard.Commands.CreateCommand
{
    public class CreateAdCommandHandler
        : IRequestExceptionHandler<CreateAdCommand, Guid> 
    {
        private readonly IBulletinBoardDbContext _dbContext;
        public CreateAdCommandHandler(IBulletinBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Guid> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var ad = new Ad
            {
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreationDate = DateTime.Now,
            };
        }
    }
}
