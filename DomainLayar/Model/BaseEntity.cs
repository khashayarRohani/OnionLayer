using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayar.Model
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
