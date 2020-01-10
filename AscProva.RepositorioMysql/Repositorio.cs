using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AscProva.RepositorioMysql
{
    public class Repositorio : IDisposable
    {

        private readonly MySqlConnection MinhaConexao;

        public Repositorio()
        {
            MinhaConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConexaoMysql"].ConnectionString);
            MinhaConexao.Open();
        }

        public void ExecutaComando(string ComandoSQL)
        {

            var CmdComando = new MySqlCommand
            {
                CommandText = ComandoSQL,
                CommandType = System.Data.CommandType.Text,
                Connection = MinhaConexao
            };

            CmdComando.ExecuteNonQuery();

        }

        public MySqlDataReader ExecutaComRetorno(string ComandoSQL)
        {
            var CmdComando = new MySqlCommand(ComandoSQL, MinhaConexao);
            return CmdComando.ExecuteReader();
        }

        public string ExecutaComRetornoUnico(string ComandoSQL)
        {
            var CmdComando = new MySqlCommand(ComandoSQL, MinhaConexao);
            return CmdComando.ExecuteScalar().ToString();
        }

        public void Dispose()
        {

            if (MinhaConexao.State == ConnectionState.Open)
                MinhaConexao.Close();

        }

    }
}
