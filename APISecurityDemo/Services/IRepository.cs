using System.Collections.Generic;

namespace APISecurityDemo.Services
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
