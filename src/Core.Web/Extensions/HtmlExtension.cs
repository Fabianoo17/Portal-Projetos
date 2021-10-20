using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Web.Extensions
{
    public static class HtmlExtension
    {
        public static string GetActiveRoute(this IHtmlHelper htmlHelper, string action, string controller, bool controllerOnly = true)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeController = (string)routeData.Values["controller"];

            var returnActive = controller.ToLower() == routeController.ToLower() && action.ToLower() == routeAction.ToLower();

            if (controllerOnly)
                returnActive = controller.ToLower() == routeController.ToLower();

            return returnActive ? "active" : "";
        }

        public static string Resumo(this string value, int tamanho = 30) {
            return value;
        }
    }
}