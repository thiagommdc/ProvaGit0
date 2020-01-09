using System.Web;
using System.Web.Optimization;

namespace AscProva
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));





            bundles.Add(new ScriptBundle("~/bundles/ascprovajs").Include(
                                        
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.mask.min.js",
                        "~/Scripts/popper.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/AscProva.js",
                        "~/Scripts/jquery.mask.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"

                        ));









            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/bundles/ascprovacss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/simple-sidebar.css",
                      "~/Content/Estilo.css"
                      ));

        }
    }
}
