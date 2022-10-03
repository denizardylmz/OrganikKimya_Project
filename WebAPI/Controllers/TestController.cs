using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Item.CreateItem;
using Application.Item.Quaries.GetItemByFilter;
using Application.Item.Query.GetItems;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPost("test")]
        public async Task<GetItemsResponse> GetAll(GetItemsRequest request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpPost("ByFilter")]
        public async Task<ItemsVm> GetByFilter([FromQuery]GetItemByFilterRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
