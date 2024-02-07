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
    public class UDEndpoint<UpdateObject, Object, UpdateService, DeleteObject, DeleteService, Id> : UpdateEndpoint<UpdateObject, Object, UpdateService>
        where UpdateService : IUpdateService<Object>
        where UpdateObject : IConvertable<Object>
        where DeleteService : IDeleteService<Id>
        where Id : IComparable
    {
        private Func<DeleteObject, Id> DeleteIdSelector { get; set; } = null!;

        public UDEndpoint(Func<DeleteObject, Id> deleteIdSelector)
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
