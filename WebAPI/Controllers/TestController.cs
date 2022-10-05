using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.DTOs;
using Application.Extensions;
using Application.Interfaces;
using Application.Item.CreateItem;
using Application.Item.Quaries.GetItemByFilter;
using Application.Item.Query.GetItems;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ODataController
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IdentityAppDb _context;
        private readonly IValidator<CreateItemCommand> _validator;

        public TestController(IMediator mediator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IdentityAppDb context, IValidator<CreateItemCommand> validator)
        {
            _mediator = mediator;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _validator = validator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreateItemCommandResponse>> Create(CreateItemCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPost("test")]
        public async Task<GetAllItemsResponse> GetAll(GetAllItemsRequest request)
        {
            return await _mediator.Send(request);
        }
        
        [Authorize(Roles = ("Admin, User"))]
        [HttpPost("ByFilter")]
        public async Task<ItemsResponse> GetByFilter([FromBody]GetItemByFilterRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(UserCreateDTO user)
        {
            var result = await _userManager.CreateAsync(new AppUser
            {
                UserName = user.Username,
            }, user.Password);

            await _roleManager.CreateAsync(new AppRole() { Name = "Admin" });
            await _roleManager.CreateAsync(new AppRole() { Name = "User" });
            
            var oldUser = await _userManager.FindByNameAsync("DenizArda");
            var userToRole = await _userManager.FindByNameAsync(user.Username);
            await _userManager.AddToRoleAsync(userToRole, "Admin");
            await _userManager.AddToRoleAsync(oldUser, "User");
            
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(UserLogInRequest dto)
        {
            AppUser user = await _userManager.FindByNameAsync(dto.Username);

            if (user != null)
            {
                await _signInManager.SignOutAsync();
                SignInResult result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
                if (result == SignInResult.Success)
                {
                    return Ok();
                }
                
            }
            return BadRequest("Invalid password or username");
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("OData")]
        [EnableQuery]
        public async Task<List<Item>> Get()
        {
            return _context.Items.ToList();
        }



    }
}
