using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Features.Accounts.Commands.Add;
using PasswordManager.Application.Features.Accounts.Commands.Delete;
using PasswordManager.Application.Features.Accounts.Commands.Update;
using PasswordManager.Application.Features.Accounts.Queries.GetById;
using PasswordManager.Application.Features.Accounts.Queries.GetList;

namespace PasswordManager.WebApi.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAccountCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            GetByIdAccountCommand getByIdAccountCommand = new() { Id = id };
            var response = await Mediator.Send(getByIdAccountCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            long userId = 1;
            GetListAccountCommand getListAccountCommand = new()
            {
                GetListAccountWithIdDto = new GetListAccountWithIdDto()
                {
                    PageRequest = pageRequest,
                    UserId = userId
                }
            };
            var response = await Mediator.Send(getListAccountCommand);
            return Ok(response);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Remove([FromRoute] long id)
        {
            DeleteAccountCommand deleteAccountCommand = new() { Id = id };
            var response = await Mediator.Send(deleteAccountCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAccountCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
