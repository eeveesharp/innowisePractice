using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.ViewModels.Client;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        private readonly IMapper _mapper;

        public ClientController(IClientServices ClientServices, IMapper mapper)
        {
            _clientServices = ClientServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientViewModel>> GetAll(CancellationToken ct)
        {
            return _mapper.Map<List<ClientViewModel>>(await _clientServices.GetAll(ct));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken ct)
        {
            await _clientServices.Delete(id, ct);
        }

        [HttpPut("{id}")]
        public async Task<ShortClientViewModel> Update(int id, AddClientViewModel Client, CancellationToken ct)
        {
            var ClientResult = _mapper.Map<Client>(Client);

            ClientResult.Id = id;

            await _clientServices.Update(ClientResult, ct);

            return _mapper.Map<ShortClientViewModel>(ClientResult);
        }

        [HttpPost]
        public async Task<ShortClientViewModel> Create(AddClientViewModel Client, CancellationToken ct)
        {
            var ClientResult = _mapper.Map<Client>(Client);

            await _clientServices.Create(ClientResult, ct);

            return _mapper.Map<ShortClientViewModel>(ClientResult);
        }
    }
}
