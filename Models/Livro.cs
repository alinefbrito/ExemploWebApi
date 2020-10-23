using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWebApi.Models
{
    public class Livro
    {
        public Livro()
        {
        }

        public Livro(int id, string nome, string categoria, decimal preco)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}