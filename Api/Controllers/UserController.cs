using Application.DTOs;
using Application.Services.Contracts;
using Domain.Commands.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace Api.Controllers
{
    [Route("users")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetUsers());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return CustomResponse(await userService.Create(command));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            return CustomResponse(await userService.Edit(command));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            return CustomResponse(await userService.Delete(id));
        }
    }
}