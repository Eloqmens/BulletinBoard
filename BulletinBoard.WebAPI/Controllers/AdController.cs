using AutoMapper;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.CreateCommand;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.DeleteCommand;
using BulletinBoard.Application.BulletinBoard.Advert.Commands.UpdateCommand;
using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdDetails;
using BulletinBoard.Application.BulletinBoard.Advert.Querries.GetAdList;
using BulletinBoard.Application.BulletinBoard.Querries.GetAdList;
using BulletinBoard.WebAPI.Models.Advert;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.WebAPI.Controllers
{
    public class AdController : BaseController
    {
        private readonly IMapper _mapper;

        public AdController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<AdListVm>> GetAll()
        {
            var query = new GetAdListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdDetailsVm>> Get(Guid id)
        {
            var query = new GetAdDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAdDto createAdDto)
        {
            var command = _mapper.Map<CreateAdCommand>(createAdDto);
            command.UserId = UserId;
            var adId = await Mediator.Send(command);
            return Ok(adId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdDto updateAdDto)
        {
            var command = _mapper.Map<UpdateAdCommand>(updateAdDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAdCommand 
            { 
                Id = id, 
                UserId = UserId 
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
