using BulletinBoard.Application.BulletinBoard.Querries.GetAdList;
using FluentValidation;

namespace BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdList
{
    public class GetAdListQueryValidator : AbstractValidator<GetAdListQuery>
    {
        public GetAdListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
