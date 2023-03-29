using AutoMapper;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdDetails
{
    public class AdDetailsVm : IMapWith<Ad>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Advert, AdDetailsVm>()
                .ForMember(adVm => adVm.Id,
                opt => opt.MapFrom(ad => ad.Id))
                .ForMember(adVm => adVm.Name,
                opt => opt.MapFrom(ad => ad.Name))
                .ForMember(adVm => adVm.Description,
                opt => opt.MapFrom(ad => ad.Description))
                .ForMember(adVm => adVm.Price,
                opt => opt.MapFrom(ad => ad.Price))
                .ForMember(adVm => adVm.CreationDate,
                opt => opt.MapFrom(ad => ad.CreationDate));
        }
    }
}
