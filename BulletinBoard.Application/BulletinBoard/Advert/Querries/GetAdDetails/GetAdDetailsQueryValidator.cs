using FluentValidation;

namespace BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdDetails
{
    public class GetAdDetailsQueryValidator : AbstractValidator<GetAdDetailsQuery>
    {
        public GetAdDetailsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
