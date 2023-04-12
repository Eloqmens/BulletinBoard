using FluentValidation;

namespace BulletinBoard.Application.BulletinBoard.Advert.Commands.CreateCommand
{
    public class CreateAdCommandValidator : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
