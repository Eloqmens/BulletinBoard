using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Commands.UpdateCommand
{
    public class UpdateAdCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
