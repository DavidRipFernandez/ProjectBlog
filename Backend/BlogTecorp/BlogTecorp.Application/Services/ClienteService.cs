using BlogTecorp.Application.DTO;
using BlogTecorp.Domain.Entities;
using BlogTecorp.Domain.Interfaces;

namespace BlogTecorp.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsyc();
            return clientes.Select(c => new ClienteDTO
            {
                ClienteId = c.ClienteId,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            });
        }
        public async Task AddAsync(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };
            await _repository.AddAsync(cliente);
        }
        public async Task<bool> UpdateAsync(int id, ClienteDTO dto)
        {
            var clienteExistente = await _repository.GetByIdAsync(id);
            if (clienteExistente == null)
            {
                return false;
            }
            clienteExistente.Name = dto.Name;
            clienteExistente.Email = dto.Email;
            clienteExistente.Phone = dto.Phone;

            await _repository.UpdateAsync(clienteExistente);
            return true;
        }
    }
}