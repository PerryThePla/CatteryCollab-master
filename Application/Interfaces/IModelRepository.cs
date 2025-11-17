using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IModelRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void AddToRepository(T item);
        public void RemoveFromRepository(T item);
        public void UpdateInRepository(T item);

    }
}
