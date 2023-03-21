using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Commands.CreateCommand
{
    public class CreateAdCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }     
        public decimal Price { get; set; }

    }
}
