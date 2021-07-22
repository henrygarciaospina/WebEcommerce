using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICarritoCompraRepository
    {
        Task<CarritoCompra> GetCarritoCompraAsync(string carritoId);
        Task<CarritoCompra> UpdateCarritoCompraAsync(CarritoCompra carritoCompra);
        Task<bool> DeletetCarritoCompraAsync(string carritoId);


    }
}
