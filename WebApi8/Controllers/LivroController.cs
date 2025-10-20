using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Livro;
using WebApi8.Models;
using WebApi8.Services.Livro;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;   
        }

        #region Listar Livros
        /// <summary>
        /// Listar Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }
        #endregion

        #region Buscar Livro Por Id
        /// <summary>
        /// Buscar Livro Por Id
        /// </summary>
        /// <param name="idLivro"></param>
        /// <returns></returns>
        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }
        #endregion

        #region Buscar Livro Por Id Autor
        /// <summary>
        /// Buscar Livro Por Id Autor
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }
        #endregion

        #region Criar Livro
        /// <summary>
        /// Criar Livro
        /// </summary>
        /// <param name="livroCriacaoDto"></param>
        /// <returns></returns>
        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }
        #endregion

        #region Editar Livro
        /// <summary>
        /// Editar Livro
        /// </summary>
        /// <param name="livroEdicaoDto"></param>
        /// <returns></returns>
        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }
        #endregion

        #region Excluir Livro
        /// <summary>
        /// Excluir Livro
        /// </summary>
        /// <param name="idLivro"></param>
        /// <returns></returns>
        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livros);
        }
        #endregion
    }
}
