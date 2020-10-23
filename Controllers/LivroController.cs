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

        // GET: api/Livro/5
        [HttpGet]
        [ActionName("getLivro")]
        public Livro Get(int id)
        {
            var livro = livros.FirstOrDefault((p) => p.Id == id);
            if (livro == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return livro;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllLivros()
        {
            return livros;
        }
        // POST: api/Livro
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Livro/5
        public void Put(int id, [FromBody]string value)
        {
            
        }
        [HttpGet]
        [ActionName("getByCategoria")]
        public IEnumerable GetLivrosByCategory(string categoria)
        {
            return livros.Where(
                (p) => string.Equals(p.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
        }

        [HttpDelete]
        [ActionName("delete")]
        public Livro Delete(int id)
        {
            Livro l = (Livro)livros.Where((p) => p.Id == id);
            int index = livros.IndexOf(l);
            livros.RemoveAt(index);
            return l;
        }

        
    }

}
