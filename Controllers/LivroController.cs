using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ExemploWebApi.Models;

namespace ExemploWebApi.Controllers
{
    public class LivroController : ApiController
    {
        List<Livro> livros = new List<Livro>(new Livro[] { new Livro(1, "Harry Potter", "Fantasia", 20.25M),
                                                            new Livro(2, "Orgulho e Preconceito", "Romance", 78.09M),
                                                            new Livro(3, "Crime e Castigo", "Drama", 57M),
                                                            new Livro(4, "O Gato Preto", "Terror", 10.34M),
                                                            new Livro(5, "Memórias Postumas de Bras Cubas", "Romance", 9.99M),
                                                            new Livro(6, "Java 8", "Programaçao", 156.98M)});




        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Livro/getLivro/5
        [HttpGet]
        [ActionName("getLivro")]
        public HttpResponseMessage Get(int id)
        {
            var livro = livros.FirstOrDefault((l) => l.Id == id);

            if (livro == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            return Request.CreateResponse<Livro>(HttpStatusCode.OK, livro);
        }

        //exemplo de método com busca em Banco de dados
        [HttpGet]
        [ActionName("getAll")]
        public HttpResponseMessage GetAllLivros()
        {
            DBConnection db = new DBConnection();
            try
            {
                db.Abrir();

                var l = db.BuscaTodos();

                return Request.CreateResponse<IEnumerable<Livro>>(HttpStatusCode.OK, l);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            }
            finally
            {
                db.Fechar();
            }
        }
        // POST: api/Livro
        [HttpPost]
        [ActionName("addItens")]
        public HttpResponseMessage Post([FromBody] List<Livro> itens)
        {
            if (itens == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            livros.AddRange(itens);
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
        }

        [HttpPost]
        [ActionName("addItensBD")]
        public HttpResponseMessage PostBD([FromBody] Livro livro)
        {
            int resp;
            DBConnection db = new DBConnection();
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
            try
            {
                db.Abrir();
                resp = db.InsereLivro(livro);
                db.Fechar();

            }
            catch (Exception)
            {
                response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(response);
            }
            finally
            {
                db.Fechar();
            }
            if (resp > 0)
            {
                response = new HttpResponseMessage(HttpStatusCode.Created);
            }
            return response;
        }

        // PUT: api/Livro/5
        [HttpPut]
        [ActionName("updateItem")]
        public HttpResponseMessage Put(int id, [FromBody] Livro item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            int index = livros.IndexOf((Livro)livros.Where((p) => p.Id == id).FirstOrDefault());
            livros[index] = item;

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [ActionName("getByCategoria")]
        public HttpResponseMessage GetLivrosByCategory(string categoria)
        {
            var l = livros.Where(
                (p) => string.Equals(p.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
            return Request.CreateResponse<IEnumerable<Livro>>(HttpStatusCode.OK, l);
        }

        [HttpDelete]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            Livro l = (Livro)livros.Where((p) => p.Id == id);
            if (l == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            int index = livros.IndexOf(l);
            livros.RemoveAt(index);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }

}
