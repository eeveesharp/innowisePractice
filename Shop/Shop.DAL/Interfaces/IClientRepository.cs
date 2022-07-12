using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Entities;

namespace Shop.DAL.Interfaces
{
    public interface IClientRepository : IGenericRepository<ClientEntity>
    {
    }
}
