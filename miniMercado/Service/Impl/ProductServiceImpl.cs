using Microsoft.AspNetCore.Mvc;
using miniMercado.Entity;
using miniMercado.Model;
using miniMercado.Repository;

namespace miniMercado.Service.Impl
{
    public class ProductServiceImpl : IProductService
    {
        private readonly ProductRepository _productoRepository;

        public ProductServiceImpl(ProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<object>> GetAllProductosAsync()
        {
            List<Producto> productos = await _productoRepository.GetAllProductosAsync();
            var productos2 = productos.Select(x => (object)new
            {
                x.Precio,
                x.Marca,
                x.Nombre,
                x.Id,
                x.Descripcion,
                x.Stock
            }).ToList();
            return productos2;
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }        
        public async Task<ResponseModel<Producto>> AddProductoAsync(Producto producto)
        {            
            var existingProducto = await _productoRepository.GetProductoByIdAsync(producto.Id);
            if (existingProducto != null)
            {
                return new ResponseModel<Producto>
                {
                    Success = false,
                    Message = "El producto ya existe.",
                    Data = producto
                };
            }
            
            await _productoRepository.AddProductoAsync(producto);
            return new ResponseModel<Producto>
            {
                Success = true,
                Message = "Producto agregado con éxito.",
                Data = producto
            };
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            await _productoRepository.UpdateProductoAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(id);
            if (producto!=null)
            {
                await _productoRepository.DeleteProductoAsync(producto);
            }            
        }
       
    }
}
