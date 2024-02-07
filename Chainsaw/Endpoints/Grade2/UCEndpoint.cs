using Endpoints.Grade1;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Grade2
{
    public class UCEndpoint<CreateObject, Object, CreateService, Id, UpdateObject, UpdateService> : CreateEndpoint<CreateObject, Object, CreateService, Id>
        where CreateService : ICreateService<Object, Id>
        where CreateObject : IConvertable<Object>
        where Id : IComparable
        where UpdateService : IUpdateService<Object>
        where UpdateObject : IConvertable<Object>
    {

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateObject model, [FromServices] UpdateService service)
        {
            if (model == null)
                return BadRequest();

            await service.UpdateAsync(model.Convert());
            return Ok();
        }
    }
}
