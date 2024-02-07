using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Grade1
{
    public class CreateEndpoint<CreateObject, Object, CreateService, Id> : Controller
        where CreateService : ICreateService<Object, Id>
        where CreateObject : IConvertable<Object>
        where Id : IComparable
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateObject model, [FromServices] CreateService service)
        {
            Id res = await service.CreateAsync(model.Convert());

            if (res == null)
                return BadRequest();

            return Ok(res);
        }
    }
}
