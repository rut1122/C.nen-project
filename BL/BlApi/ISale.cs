using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface Isale<T>
    {
        int Create(T item);
        T? Read(int id);
        T? Read(Func<T, bool> filter);
        IEnumerable<T?> ReadAll(Func<T, bool>? filter = null);
        void Update(T item);
        void Delete(int id);

    }
}
