using AscProva.Modelo;
using AscProva.RepositorioMysql;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace AscProva.Aplicacao
{
    public class AplicacaoAlunoMysql
    {

        private Repositorio BancoDeDados;


        public AplicacaoAlunoMysql()
        {
            BancoDeDados = new Repositorio();
        }

        public void Salva(Alunos Aluno)
        {
            using (BancoDeDados = new Repositorio())
            {
                var SQLExecuta = string.Format(
                    "Insert into Alunos(Nome, Turma, Media, MediaEspecial, ProvaUm, ProvaDois, ProvaTres, ProvaFinal, ProvaEspecial) values('{0}', '{1}', 0, 0, 0, 0, 0, 0, 0)",
                    Aluno.Nome, Aluno.Turma
                    );
                BancoDeDados.ExecutaComando(SQLExecuta);
                BancoDeDados.Dispose();
            }
        }


        public void Atualiza(Alunos Aluno)
        {
            using (BancoDeDados = new Repositorio())
            {
                var SQLExecuta = string.Format(
                    "update Alunos set Media='{0}', MediaEspecial='{1}', ProvaUm='{2}', ProvaDois='{3}', ProvaTres='{4}', ProvaFinal='{5}', ProvaEspecial='{6}' where Id='{7}'",
                    Aluno.Media.ToString().Replace(",", "."),
                    Aluno.MediaEspecial.ToString().Replace(",", "."),
                    Aluno.ProvaUm.ToString().Replace(",", "."),
                    Aluno.ProvaDois.ToString().Replace(",", "."),
                    Aluno.ProvaTres.ToString().Replace(",", "."),
                    Aluno.ProvaFinal.ToString().Replace(",", "."),
                    Aluno.ProvaEspecial.ToString().Replace(",", "."),
                    Aluno.Id
                    );
                BancoDeDados.ExecutaComando(SQLExecuta);
                BancoDeDados.Dispose();
            }

        }

        public void Excluir(Alunos Aluno)
        {
            using (BancoDeDados = new Repositorio())
            {
                var SQLExecuta = string.Format(
                    "delete from Alunos where Id='{0}';",
                    Aluno.Id
                    );
                BancoDeDados.ExecutaComando(SQLExecuta);
                BancoDeDados.Dispose();
            }
        }

        public IEnumerable<Alunos> Selecionar(Alunos Aluno)
        {

            string SQLExecuta;
            string SQLComplemento;

            MySqlDataReader DataReader;
            BancoDeDados = new Repositorio();

            var AlunoLista = new List<Alunos> { };


            if (Aluno.Id > 0)
            {
                SQLExecuta = string.Format(
                   "Select * from Alunos where Id={0}",
                   Aluno.Id
                   );
            }
            else
            {
                SQLExecuta = "Select * from Alunos";
                SQLComplemento = "";

                if (Aluno.Nome != "") { SQLComplemento += " or Nome like '%" + Aluno.Nome + "%'"; }

                if (SQLComplemento == "")
                    goto SkipToEnd;

                SQLComplemento = SQLComplemento.Trim();
                SQLComplemento = SQLComplemento.Remove(0, 2);
                SQLExecuta = SQLExecuta + " where " + SQLComplemento;

            SkipToEnd:;

                SQLExecuta = SQLExecuta + " ORDER BY MediaEspecial DESC, Media DESC";
            }

            DataReader = BancoDeDados.ExecutaComRetorno(SQLExecuta);

            while (DataReader.Read())
            {
                AlunoLista.Add(new Alunos
                {
                    Id = Convert.ToInt32(DataReader["Id"]),
                    Nome = DataReader["Nome"].ToString(),
                    Turma = DataReader["Turma"].ToString(),
                    Media = Math.Round(Convert.ToDecimal(DataReader["Media"]), 1),
                    MediaEspecial = Math.Round(Convert.ToDecimal(DataReader["MediaEspecial"]), 1),
                    ProvaUm = Math.Round(Convert.ToDecimal(DataReader["ProvaUm"]), 1),
                    ProvaDois = Math.Round(Convert.ToDecimal(DataReader["ProvaDois"]), 1),
                    ProvaTres = Math.Round(Convert.ToDecimal(DataReader["ProvaTres"]), 1),
                    ProvaFinal = Math.Round(Convert.ToDecimal(DataReader["ProvaFinal"]), 1),
                    ProvaEspecial = Math.Round(Convert.ToDecimal(DataReader["ProvaEspecial"]), 1),

                });
            }

            BancoDeDados.Dispose();

            return AlunoLista;

        }


    }
}
