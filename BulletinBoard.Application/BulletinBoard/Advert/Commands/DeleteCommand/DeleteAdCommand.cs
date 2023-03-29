using MediatR;

namespace BulletinBoard.Application.BulletinBoard.Advert.Commands.DeleteCommand
{
    public class DeleteAdCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
