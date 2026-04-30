

using BlogTecorp.Domain.Entities;
using BlogTecorp.Domain.Interfaces;
using BlogTecorp.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTecorp.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BlogTecorpContext _context;
        public ClienteRepository(BlogTecorpContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsyc()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
