using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class ClientServices : GenericServices<Client, ClientEntity>, IClientServices
    {
        public ClientServices(IGenericRepository<ClientEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
