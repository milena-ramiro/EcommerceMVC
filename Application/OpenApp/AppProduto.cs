using Application.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduto : InterfaceProductApp
    {
        IProduct _IProduto;
        IServiceProduct _IService;

        public AppProduto(IProduct IProduto, IServiceProduct IService)
        {
            _IProduto = IProduto;
            _IService = IService;
        }


        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            return await _IProduto.ListarProdutosCarrinhoUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _IProduto.ObterProdutoCarrinho(idProdutoCarrinho);
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            return await _IProduto.ListarProdutosUsuario(userId);
        }



        public async Task AddProduct(Produto produto)
        {
            await _IService.AddProduto(produto);
        }

        public async Task UpdateProduct(Produto produto)
        {
            await _IService.UpdateProduto(produto);
        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            return await _IService.ListarProdutosComEstoque(descricao);
        }




        

        public async Task Add(Produto Objeto)
        {
            await _IProduto.Add(Objeto);
        }

        public async Task Update(Produto Objeto)
        {
            await _IProduto.Update(Objeto);
        }

        public async Task Delete(Produto Objeto)
        {
            await _IProduto.Delete(Objeto);
        }

        public async Task<Produto> GetEntityById(int Id)
        {
            return await _IProduto.GetEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduto.List();
        }
        
    }
}
