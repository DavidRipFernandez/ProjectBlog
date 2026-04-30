using BlogTecorp.Application.DTO;
using BlogTecorp.Domain.Interfaces;
using BlogTecorp.Domain.Entities;
using BlogTecorp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BlogTecorp.Application.Services
{
    public class ProductService
    {
        private readonly IProductoRepository  _repository;
        public ProductService(IProductoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(e => new ProductDTO
            {
                ProductId = e.ProductId,
                Name = e.Name,
                Price = e.Price
            });
        }
        public async Task AddAsync(ProductDTO dto)
        {
            var nuevoProducto = new Product { 
                Name = dto.Name,
                Price = dto.Price 
            };
            await _repository.AddAsync(nuevoProducto);
        }

    }
}
