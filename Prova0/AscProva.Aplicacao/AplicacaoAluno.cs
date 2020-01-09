using AscProva.Modelo;
using AscProva.RepositorioEntity;
using System.Collections.Generic;
using System.Linq;

namespace AscProva.Aplicacao
{
    public class AplicacaoAluno
    {

        private readonly Repositorio BancoDeDados;

        public AplicacaoAluno()
        {
            BancoDeDados = new Repositorio();
        }


        public void Salvar(Alunos Entidade)
        {
            if (Entidade.Id > 0)
            {
                var AlunoAlterar = BancoDeDados.Alunos.First(x => x.Id == Entidade.Id);

                AlunoAlterar.Nome = Entidade.Nome;
                AlunoAlterar.Turma = Entidade.Turma;
            }
            else
            {
                BancoDeDados.Alunos.Add(Entidade);
            }

            BancoDeDados.SaveChanges();

        }

        public void Excluir(Alunos Entidade)
        {

            var AlunoExcluir = BancoDeDados.Alunos.First(x => x.Id == Entidade.Id);
            BancoDeDados.Set<Alunos>().Remove(AlunoExcluir);
            BancoDeDados.SaveChanges();
        }

        public IEnumerable<Alunos> Selecionar(Alunos Entidade)
        {

            IEnumerable<Alunos> AlunoLista = null;

            if (Entidade.Id > 0)
            {

                AlunoLista = BancoDeDados.Alunos.Where(x => x.Id == Entidade.Id);

            }
            else
            {

                if (Entidade.Nome != null)
                { AlunoLista = BancoDeDados.Alunos.Where(x => x.Nome.Contains(Entidade.Nome)); goto Final; }
                
                AlunoLista = BancoDeDados.Alunos;

            }

        Final:;

            return AlunoLista;

            //throw new NotImplementedException();
        }

    }

}
