using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReadService<C, Object, Searchparam,Id>
    {
        public Task<Object> ReadAsync(Searchparam searchparam);
        public Task<Id> CreateAsync(C model);
        public Task UpdateAsync(Object model);
        public Task DeleteAsync(Id id);
    }
}
