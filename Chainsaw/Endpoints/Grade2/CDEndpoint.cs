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
    public class CDEndpoint<CreateObject, Object, Id, CreateService, DeleteObject, DeleteService> : CreateEndpoint<CreateObject, Object, CreateService, Id>
        where DeleteService : IDeleteService<Id>
        where CreateObject : IConvertable<Object>
        where Id : IComparable
        where CreateService : ICreateService<Object, Id>
    {
        private Func<DeleteObject, Id> DeleteIdSelector { get; set; } = null!;

        public CDEndpoint(Func<DeleteObject, Id> deleteIdSelector)
        {
            DeleteIdSelector = deleteIdSelector;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteObject model, [FromServices] DeleteService service)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await service.DeleteAsync(DeleteIdSelector(model));
            return Ok();
        }
    }
}
