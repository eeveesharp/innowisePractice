using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ClientRepository : GenericRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
