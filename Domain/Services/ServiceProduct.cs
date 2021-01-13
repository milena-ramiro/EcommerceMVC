using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _IProduto;

        public ServiceProduct(IProduct IProduto)
        {
            _IProduto = IProduto;
        }

        public async Task AddProduto(Produto produto)
        {
            bool validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            bool validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
            bool validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if(validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _IProduto.Add(produto);
            }

        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return await _IProduto.ListarProdutos(p => p.QtdEstoque > 0);
            else
                return await _IProduto.ListarProdutos(p => p.QtdEstoque > 0 && p.Nome.ToUpper().Contains(descricao.ToUpper()));
        }

        public async Task UpdateProduto(Produto produto)
        {
            bool validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            bool validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
            bool validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if(validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataAlteracao = DateTime.Now;
                await _IProduto.Update(produto);
            }
        }
    }
}
