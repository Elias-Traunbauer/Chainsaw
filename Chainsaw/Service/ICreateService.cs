using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICreateService<Create,Id>
    {
        public Task<Id> CreateAsync(Create model);
    }
}
