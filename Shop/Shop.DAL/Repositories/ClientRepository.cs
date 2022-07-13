using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ClientRepository : GenericRepository<ClientEntity>, IGenericRepository<ClientEntity>
    {
        public ClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
