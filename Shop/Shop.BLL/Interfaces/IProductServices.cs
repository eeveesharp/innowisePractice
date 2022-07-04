using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface IProductServices<Product>
    {
        IEnumerable<Product> GetAll();

        Product Get(int id);

        Product Create(Product item);

        Product Update(Product item);

        void Delete(int id);
    }
}
