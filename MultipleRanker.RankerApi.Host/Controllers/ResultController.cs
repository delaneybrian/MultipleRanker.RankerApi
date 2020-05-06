using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task AddResult()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveResult()
        {
            throw new NotImplementedException();
        }
    }
}
