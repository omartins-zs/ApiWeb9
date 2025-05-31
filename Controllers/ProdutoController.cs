using ApiWeb9.Data;
using ApiWeb9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiWeb9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ProdutoModel>> GetProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoModel> GetProdutoById(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não localizado!!!");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoModel> CriarProduto(ProdutoModel produtoModel)
        {
            if (produtoModel == null)
            {
                return BadRequest("Ocorreu um erro na solicitação!");
            }

            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProdutoById), new { id = produtoModel.Id }, produtoModel);
        }

        [HttpPatch("{id}")]
        public ActionResult<ProdutoModel> EditarProduto(ProdutoModel produtoModel, int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não localizado!!!");
            }

            // Atualiza os campos
            produto.Nome = produtoModel.Nome;
            produto.Preco = produtoModel.Preco;
            produto.Descricao = produtoModel.Descricao;
            produto.Marca = produtoModel.Marca;
            produto.QuantidadeEstoque = produtoModel.QuantidadeEstoque;
            produto.CodigoDeBarras = produtoModel.CodigoDeBarras;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return Ok(produto); // Retorna o produto atualizado
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Registro não localizado!!!");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok("Produto excluído com sucesso!");
        }
    }
}
