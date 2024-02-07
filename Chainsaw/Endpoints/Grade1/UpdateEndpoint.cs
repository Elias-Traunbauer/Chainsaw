using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Grade1
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UpdateEndpoint<UpdateObject, Object, Service> : Controller
        where Service : IUpdateService<Object>
        where UpdateObject : IConvertable<Object>
    {
        public UpdateEndpoint()
        {
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateObject model, [FromServices] Service service)
        {
            if (model == null)
                return BadRequest();

            await service.UpdateAsync(model.Convert());
            return Ok();
        }
    }
}
