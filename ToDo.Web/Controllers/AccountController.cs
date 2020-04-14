using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Account;
using Cynosura.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Web.Controllers
{
    [Route("api")]
    [ServiceFilter(typeof(ApiExceptionFilterAttribute))]
    [ValidateModel]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<CreatedEntity<int>> RegisterAsync([FromBody] Register register)
        {
            return await _mediator.Send(register);
        }
    }
}
