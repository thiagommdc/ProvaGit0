using AscProva.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AscProva.Aplicacao;

namespace AscProva.Controllers
{
    public class AlunoController : Controller
    {

        AplicacaoAlunoMysql BancoDeDadosMysql;

        //var BancoDeDados = new AplicacaoAluno();

        public AlunoController()
        {
            BancoDeDadosMysql = new AplicacaoAlunoMysql();
        }

        public ActionResult Index()
        {
            return View(BancoDeDadosMysql.Selecionar(new Alunos()));
        }
        
        public ActionResult Cadastrar(Alunos Aluno)
        {
                        
            ViewBag.Javascript = "FechaCadastro()";

            BancoDeDadosMysql.Salva(Aluno);

            return PartialView("_ListaAlunos", BancoDeDadosMysql.Selecionar(new Alunos()));
        }


        public ActionResult PreencheEdicao(int Id)
        {

            ViewBag.Javascript = "AbreModalEdicao()";

            return PartialView("_Editar", BancoDeDadosMysql.Selecionar(new Alunos() { Id = Id }).First());

        }

        public ActionResult Editar(Alunos Aluno)
        {

            ViewBag.Javascript = "FechaExclusao()";

            BancoDeDadosMysql.Atualiza(Aluno);

            return PartialView("_ListaAlunos", BancoDeDadosMysql.Selecionar(new Alunos()));

        }

        public ActionResult Excluir(int Id)
        {

            ViewBag.Javascript = "FechaExclusao()";

            BancoDeDadosMysql.Excluir(new Alunos(){ Id = Id );

            return PartialView("_ListaAlunos", BancoDeDadosMysql.Selecionar(new Alunos()));

        }

    }
}