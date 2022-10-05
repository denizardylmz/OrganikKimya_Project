using Application.DTOs;
using Application.Identity;
using Application.Item.Quaries.GetItemByFilterOdata;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("LogIn")]
        public async Task<LogInResponse> Login(UserLogInRequest dto)
        {
            return await _mediator.Send(dto);
        }


        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut([FromRoute] UserLogOutRequest request)
        { 
            await _mediator.Send(request);
            return Ok("Logout successfully");
        }

        [Authorize(Roles = "Admin, User")]
        [EnableQuery(PageSize = 20)]
        [HttpPost("GetByFilter")]
        public async Task<List<ItemDTO>> GetByFilter([FromRoute]GetByFilterRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
