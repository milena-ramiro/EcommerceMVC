using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Entities.Entities.Enums;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryProduct()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtosCarrinhosUsuario = await (from p in banco.Produto
                                                      join c in banco.CompraUsuario
                                                      on p.Id equals c.IdProduto
                                                      join co in banco.Compra
                                                      on c.IdCompra equals co.Id
                                                      where c.UserId.Equals(userId)
                                                      && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                      select new Produto
                                                      {
                                                          Id = p.Id,
                                                          Nome = p.Nome,
                                                          Descricao = p.Descricao,
                                                          Observacao = p.Observacao,
                                                          Valor = p.Valor,
                                                          QtdCompra = p.QtdCompra,
                                                          IdProdutoCarrinho = c.Id,
                                                          Url = p.Url,
                                                          DataCompra = co.DataCompra
                                                      }).AsNoTracking().ToListAsync();

                return produtosCarrinhosUsuario;
            }
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using(var banco  = new ContextBase(_optionsbuilder))
            {
                var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                     join c in banco.CompraUsuario
                                                     on p.Id equals c.IdProduto
                                                     where c.Id.Equals(idProdutoCarrinho)
                                                     && c.Estado == EnumEstadoCompra.Produto_Carrinho
                                                     select new Produto
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url
                                                     }).AsNoTracking().FirstOrDefaultAsync();
                return produtosCarrinhoUsuario;
            }
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            using(var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }

        
    }
}
