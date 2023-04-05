using AutoMapper;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.CreateCommand;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.UpdateCommand;
using BulletinBoard.Application.Common.Mappings;

namespace BulletinBoard.WebAPI.Models.Advert
{
    public class UpdateAdDto : IMapWith<UpdateAdCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAdDto, CreateAdCommand>()
                .ForMember(adCommand => adCommand.Name,
                opt => opt.MapFrom(adDto => adDto.Name))
                .ForMember(adCommand => adCommand.Description,
                opt => opt.MapFrom(adDto => adDto.Description))
                .ForMember(adCommand => adCommand.Price,
                opt => opt.MapFrom(adDto => adDto.Price));
        }
    }
}
