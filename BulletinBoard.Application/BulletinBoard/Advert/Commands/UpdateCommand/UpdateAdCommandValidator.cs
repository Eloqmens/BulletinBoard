using FluentValidation;

namespace BulletinBoard.Application.BulletinBoard.Advert.Commands.UpdateCommand
{
    public class UpdateAdCommandValidator : AbstractValidator<UpdateAdCommand>
    {
        public UpdateAdCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
        }
    }
}
