using InfnetMovieDataBase.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InfnetMovieDataBase.Repository
{
    public class FilmeRepository
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InfnetMovieDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Métodos para manipulação de banco de dados:

        //Listar
        public IEnumerable<Filme> ListarFilmes()
        {

            var filmes = new List<Filme>();

            using (var connection = new SqlConnection(connectionString))
            {

                var cmdText = "SELECT * FROM Filme";
                var select = new SqlCommand(cmdText, connection);


                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var filme = new Filme();
                            filme.Id = (int)reader["Id"];
                            filme.Titulo = reader["Titulo"].ToString();
                            filme.TituloOriginal = reader["TituloOriginal"].ToString();
                            filme.Ano = (int)reader["Ano"];
                            filme.Duracao = (int)reader["Duracao"];

                            filmes.Add(filme);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }


            }
            return filmes;
        }

        //Criar
        public void CriarFilme(Filme filme)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Filme (Titulo, TituloOriginal, Ano, Duracao) Values(@Titulo, @TituloOriginal, @Ano, @Duracao)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@TituloOriginal", filme.TituloOriginal);
                cmd.Parameters.AddWithValue("@Ano", filme.Ano);
                cmd.Parameters.AddWithValue("@Duracao", filme.Duracao);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //Atualizar
        public void AtualizarFilme(Filme filme)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Filme SET Titulo=@Titulo, TituloOriginal=@TituloOriginal, Ano=@Ano, Duracao=@Duracao WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", filme.Id);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@TituloOriginal", filme.TituloOriginal);
                cmd.Parameters.AddWithValue("@Ano", filme.Ano);
                cmd.Parameters.AddWithValue("@Duracao", filme.Duracao);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //Detalhar
        public Filme DetalharFilme(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Titulo, TituloOriginal, Ano, Duracao FROM Filme WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Filme filme = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                filme = new Filme();
                                filme.Id = (int)reader["Id"];
                                filme.Titulo = reader["Titulo"].ToString();
                                filme.TituloOriginal = reader["TituloOriginal"].ToString();
                                filme.Ano = (int)reader["Ano"];
                                filme.Duracao = (int)reader["Duracao"];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return filme;
            }
        }

        //Excluir
        public void ExcluirFilme(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE Filme WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}

