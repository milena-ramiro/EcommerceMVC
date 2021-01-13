using Domain.Interfaces.InterfaceCompra;
using Entities.Entities;
using Entities.Entities.Enums;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class RepositoryCompra : RepositoryGenerics<Compra>, ICompra
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryCompra()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<Compra> CompraPorEstado(string userId, EnumEstadoCompra estado)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Compra.FirstOrDefaultAsync(c => c.Estado == estado && c.UserId == userId);
            }
        }
    }
}
