using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Grade1
{
    public class DeleteEndpoint<Id, Service, Object, DeleteObject> : Controller
        where Id : IComparable
        where Service : IDeleteService<Id>
    {
        private Func<DeleteObject, Id> DeleteIdSelector { get; set; } = null!;

        public DeleteEndpoint(Func<DeleteObject, Id> deleteIdSelector)
        {
            DeleteIdSelector = deleteIdSelector;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteObject model, [FromServices] Service service)
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
