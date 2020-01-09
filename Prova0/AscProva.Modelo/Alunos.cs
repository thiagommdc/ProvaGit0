using System.ComponentModel.DataAnnotations;

namespace AscProva.Modelo
{
    public class Alunos
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do aluno")]
        public string Nome { get; set; }

        public string Turma { get; set; }

        public decimal Media { get; set; }

        public decimal MediaEspecial { get; set; }

        public decimal ProvaUm { get; set; }

        public decimal ProvaDois { get; set; }

        public decimal ProvaTres { get; set; }

        public decimal ProvaFinal { get; set; }

        public decimal ProvaEspecial { get; set; }

    }
}
