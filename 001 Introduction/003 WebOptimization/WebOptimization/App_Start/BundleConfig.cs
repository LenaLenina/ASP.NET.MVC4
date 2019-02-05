using System.Web;
using System.Web.Optimization;

namespace _07_BundlingAndMinification
{
    public class BundleConfig
    {

        // ASP.NET Web Optimization Framework - набор компонентов позволяющих оптимизировать время загрузки приложения посредством уменьшения размера JS и CSS файлов,
        // а также уменьшения количества запросов к серверу посредством объединения нескольких файлов в один bundle.

        // Оптимизация будет работать если собрать проект в release версии
        // Для переключения на release измените файл web.config
        // <compilation debug="false" targetFramework="4.5" />

        public static void RegisterBundles(BundleCollection bundles)
        {
            // StyleBundle - бандл для стилей. Минимизирует и объединяет несколько CSS файлов.
            // Для того что бы не нарушить пути к ресурсам определенным в CSS файлах, название папки такое же как и папки с исходными стилями.
            bundles.Add(new StyleBundle("~/content/css")
                    .Include("~/Content/Site.css"));

            // Данный StyleBundle будет работать не правильно из-за пусти ~/bundles/css
            //bundles.Add(new StyleBundle("~/bundles/css")
            //    .Include("~/Content/Site.css")

            // modernizr-* - такая запись подгрузит все скрипты, которые начинаются с modernizr-
            // это позволяет избежать необходимости пересобрать проект после замены библиотеки modernizr на новую версию

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                    .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/javaScripts")
                    .Include("~/Scripts/jquery*")
                    .Include("~/Scripts/knockout-2.1.0.js"));
        }
    }
}
