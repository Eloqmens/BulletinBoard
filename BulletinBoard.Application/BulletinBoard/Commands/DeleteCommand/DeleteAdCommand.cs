using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Commands.DeleteCommand
{
    public class DeleteAdCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
