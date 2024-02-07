using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDeleteService<Id>
    {
        public Task DeleteAsync(Id id);
    }
}
