using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Application.BulletinBoard.Querries.GetAdList
{
    public class GetAdListQuery : IRequest<AdListVm>
    {
        public Guid UserId { get; set; }
        
    }
}
