using ApiCatalogGames.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Repositories
{
    public class GameSqlServerRepository : IGameRepository
    {

        private readonly SqlConnection sqlConnection;

        public GameSqlServerRepository(IConfiguration configuration )
        {
            this.sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")) ;
        }

        public Task Create(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var comando = $"delete from Jogos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Game>> Get(int page, int count)
        {
            var games = new List<Game>();

            var comando = $"select *from Jogos order by id offset {((page - 1) * count)} rows fetch next {count} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"],
                });

            }
                await sqlConnection.CloseAsync();

                return games;
        }

        public async Task<Game> Get(Guid id)
        {
            Game game = null;


            var comando = $"select * from Jogos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                game=new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"],
                };

            }
                await sqlConnection.CloseAsync();

                return game;
        }

        public async Task<List<Game>> Get(string Name, string produtora)
        {
          var games = new List<Game>();

            var comando = $"select * from Jogos where Nome = '{Name}' and Produtora = '{produtora}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"],
                });

            }
                await sqlConnection.CloseAsync();

                return games;
        }

        public Task Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
