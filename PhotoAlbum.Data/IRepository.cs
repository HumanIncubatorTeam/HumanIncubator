using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Data
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T Find(Guid id);
        void Create(T item);
        void Edit(T item);
        void Delete(Guid id);

    }
}
