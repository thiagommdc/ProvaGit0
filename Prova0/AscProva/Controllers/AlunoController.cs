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
        
        public ActionResult Index()
        {

            var BancoDeDadosMysql = new AplicacaoAlunoMysql();

            return View(BancoDeDadosMysql.Selecionar(new Alunos()));
        }

        public ActionResult Cadastrar(Alunos Aluno)
        {

            if (!Request.IsAjaxRequest())
                return View("Cadastrar");
            
            var BancoDeDados = new AplicacaoAluno();
            var BancoDeDadosMysql = new AplicacaoAlunoMysql();

            BancoDeDados.Salvar(Aluno);
            BancoDeDadosMysql.Salva(Aluno);

            return PartialView("_Cadastrar");
        }


        public ActionResult Editar(Alunos Aluno)
        {

            var BancoDeDados = new AplicacaoAluno();
            var BancoDeDadosMysql = new AplicacaoAlunoMysql();

            if (!Request.IsAjaxRequest())
            {
                BancoDeDadosMysql.Selecionar(Aluno);
                return PartialView("_Editar");
            }

            BancoDeDados.Salvar(Aluno);
            BancoDeDadosMysql.Atualiza(Aluno);
            
            return PartialView("_ListaAlunos");

        }
        
        public ActionResult Excluir(Alunos Aluno)
        {

            var BancoDeDados = new AplicacaoAluno();
            var BancoDeDadosMysql = new AplicacaoAlunoMysql();
            
            BancoDeDados.Excluir(Aluno);
            BancoDeDadosMysql.Excluir(Aluno);

            return PartialView("_ListaAlunos");

        }

    }
}