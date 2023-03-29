using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Application.BulletinBoard.Ad.Querries.GetAdDetails
{
    public class GetAdDetailsQuery : IRequest<AdDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
