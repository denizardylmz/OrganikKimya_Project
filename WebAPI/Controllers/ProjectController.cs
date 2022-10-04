
using Application.DTOs;
using Application.Item.Quaries.GetItemByFilterOdata;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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
        public async Task<IActionResult> Login(UserLogInDTO dto)
        {
            var result = await _mediator.Send(dto);
            if (result == SignInResult.Success)
            {
                return Ok("Login Success");
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }


        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut([FromRoute]UserLogOutRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok("Logout Success");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
