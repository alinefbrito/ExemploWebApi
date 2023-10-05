using ExemploWebApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWebApi.Controllers
{
    public class DBConnection
    {
        //SqlConnection conn;
        readonly MySqlConnection conn2;

        //servidor de banco de dados
        static string host = "localhost";
        //nome do banco de dados
        static readonly string database = "dblivros";
        //usuário de conexão do banco de dados
        static readonly string userDB = "root";
        //senha de conexão do banco de dados
        static readonly string password = "";
        //string de conexão ao BD
        public static string strProvider = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;


        public static Boolean novo = false;
        public String sql;

        public DBConnection()
        {

            //sql = "SELECT * FROM tb_empregado WHERE pk_empregado = 7";
            //instância a conexão
            conn2 = new MySqlConnection(strProvider);
            //Abre uma conexão de banco de dados com as configurações de
            //propriedade especificadas pelo ConnectionString
            

        }

        
        public List<Livro> BuscaTodos()
        {
            //Fornece uma maneira de ler um fluxo somente de
            //encaminhamento de linhas com base em um banco de dados SQL Server.
            MySqlDataReader reader;
            // SqlCommand é uma instrução Transact-SQL ou procedimento armazenado
            // para execução em um banco de dados SQL Server
            sql = "SELECT * FROM livro;";
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            //Envia o comando para a conexão e cria um
            //SqlDataReader .
            reader = cmd.ExecuteReader();
            List<Livro> l = new List<Livro>();
            //verfifica se o data reader tem 1 ou mais resultado
            if (reader.HasRows)
            {
                // repete enquanto possuir registros a serem lidos
                while (reader.Read())
                {
                    l.Add(new Livro(int.Parse(reader["id_livro"].ToString()), reader["titulo"].ToString(), reader["genero"].ToString(), Decimal.Parse(reader["preco"].ToString())));

                }
            }
            return l;

        }


        public int InsereLivro(Livro l)
        {

            MySqlCommand comm = conn2.CreateCommand();
            comm.CommandText = "INSERT INTO livro (titulo, genero, preco) VALUES(@titulo, @genero, @preco)";
            comm.Parameters.AddWithValue("@titulo", l.Nome);
            comm.Parameters.AddWithValue("@genero", l.Categoria);
            comm.Parameters.AddWithValue("@preco", l.Preco);
            return comm.ExecuteNonQuery();


        }
        public void Abrir()
        {
            conn2.Open();
        }
        public void Fechar()
        {
            conn2.Close();
        }
    }
}