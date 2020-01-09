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
                    "Insert into Alunos(Nome, Turma) values('{0}', '{1}')",
                    Aluno.Nome, Aluno.Turma
                    );
                BancoDeDados.ExecutaComando(SQLExecuta);

            }
        }


        public void Atualiza(Alunos Aluno)
        {
            using (BancoDeDados = new Repositorio())
            {
                var SQLExecuta = string.Format(
                    "update Alunos set Nome='{0}', Media='{1}', MediaEspecial='{2}', ProvaUm='{3}', ProvaDois='{4}', ProvaTres='{5}', ProvaFinal='{6}', ProvaEspecial='{7}' where Id='{8}'",
                    Aluno.Nome,
                    Aluno.Media,
                    Aluno.MediaEspecial,
                    Aluno.ProvaUm,
                    Aluno.ProvaDois,
                    Aluno.ProvaTres,
                    Aluno.ProvaFinal,
                    Aluno.ProvaEspecial,
                    Aluno.Id
                    );
                BancoDeDados.ExecutaComando(SQLExecuta);
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
                   "Select * from Aluno where Id={0}",
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
                SQLExecuta = SQLExecuta + " where " + SQLComplemento + " ORDER BY MediaEspecial DESC, Media DESC";

            SkipToEnd:;
            }

            DataReader = BancoDeDados.ExecutaComRetorno(SQLExecuta);

            while (DataReader.Read())
            {
                AlunoLista.Add(new Alunos
                {
                    Id = Convert.ToInt32(DataReader["Id"]),
                    Nome = DataReader["Nome"].ToString(),
                    Turma = DataReader["Turma"].ToString(),
                    Media = Convert.ToDecimal(DataReader["Media"]),
                    MediaEspecial = Convert.ToDecimal(DataReader["MediaEspecial"]),
                    ProvaUm = Convert.ToDecimal(DataReader["ProvaUm"]),
                    ProvaDois = Convert.ToDecimal(DataReader["ProvaDois"]),
                    ProvaTres = Convert.ToDecimal(DataReader["ProvaTres"]),
                    ProvaFinal = Convert.ToDecimal(DataReader["ProvaFinal"]),
                    ProvaEspecial = Convert.ToDecimal(DataReader["ProvaEspecial"]),

                });
            }

            BancoDeDados.Dispose();

            return AlunoLista;

        }


    }
}
