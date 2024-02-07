using Endpoints.Grade2;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Grade3
{
    public class CUDEndpoint<CreateObject, Object, Id, CreateService, UpdateObject, UpdateService, DeleteObject, DeleteService> :CUEndpoint<CreateObject, Object, Id, CreateService, UpdateObject, UpdateService>
        where CreateObject : IConvertable<Object>
        where Id : IComparable
        where CreateService : ICreateService<Object, Id>
        where UpdateService : IUpdateService<Object>
        where UpdateObject : IConvertable<Object>
        where DeleteService : IDeleteService<Id>
    {
        private Func<DeleteObject, Id> DeleteIdSelector { get; set; } = null!;

        public CUDEndpoint(Func<DeleteObject, Id> deleteIdSelector)
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
