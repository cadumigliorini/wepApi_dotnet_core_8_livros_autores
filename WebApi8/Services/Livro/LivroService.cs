using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Dto.Livro;
using WebApi8.Models;

namespace WebApi8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        #region Buscar Livro Por Id
        /// <summary>
        /// Buscar Livro Por Id
        /// </summary>
        /// <param name="idLivro"></param>
        /// <returns></returns>
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion

        #region Buscar Livro Por Id Autor
        /// <summary>
        /// Buscar Livro Por Id Autor
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(x => x.Autor)
                    .Where(x => x.Autor.Id == idAutor)
                    .ToListAsync();

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encomtrado!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livros encontrados!";

                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion

        #region Criar Livro
        /// <summary>
        /// Criar Livro
        /// </summary>
        /// <param name="livroCriacaoDto"></param>
        /// <returns></returns>
        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor encontrado!";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(x => x.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion

        #region Editar Livro
        /// <summary>
        /// Editar Livro
        /// </summary>
        /// <param name="livroEdicaoDto"></param>
        /// <returns></returns>
        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(x => x.Autor)
                    .FirstOrDefaultAsync(x => x.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id  == livroEdicaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor encontrado!";
                    return resposta;
                }

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de livro encontrado!";
                    return resposta;
                }

                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion

        #region Excluir Livro
        /// <summary>
        /// Excluir Livro
        /// </summary>
        /// <param name="idLivro"></param>
        /// <returns></returns>
        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == idLivro);

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro excluído com sucesso!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion

        #region Listar Livros
        /// <summary>
        /// Listar Livros
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(x => x.Autor).ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        #endregion
    }
}
