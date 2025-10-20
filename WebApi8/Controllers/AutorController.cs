using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Autor;
using WebApi8.Models;
using WebApi8.Services.Autor;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        #region Listar Autores
        /// <summary>
        /// Listar Autores
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }
        #endregion

        #region Buscar Autro Por Id
        /// <summary>
        /// Buscar Autor Por Id
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }
        #endregion

        #region Buscar Autor Por Id Livro
        /// <summary>
        /// Buscar Autor Por Id Livro
        /// </summary>
        /// <param name="idLivro"></param>
        /// <returns></returns>
        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idLivro);
            return Ok(autor);
        }
        #endregion

        #region Criar Autor
        /// <summary>
        /// Criar Autor
        /// </summary>
        /// <param name="autorCriacaoDto"></param>
        /// <returns></returns>
        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }
        #endregion

        #region Editar Autor
        /// <summary>
        /// Editar Autor
        /// </summary>
        /// <param name="autorEdicaoDto"></param>
        /// <returns></returns>
        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autores);
        }
        #endregion

        #region Excluir Autor
        /// <summary>
        /// Excluir Autor
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }
        #endregion
    }
}
