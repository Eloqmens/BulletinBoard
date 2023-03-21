using AutoMapper;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Application.BulletinBoard.Querries.GetAdList
{
    public class AdLookupDto : IMapWith<Ad>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ad, AdLookupDto>()
                .ForMember(adDto => adDto.Id,
                opt => opt.MapFrom(ad => ad.Id))
                .ForMember(adDto => adDto.Name,
                opt => opt.MapFrom(ad => ad.Name));
        }
    }
}
