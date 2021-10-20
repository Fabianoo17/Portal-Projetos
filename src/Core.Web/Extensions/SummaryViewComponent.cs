using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Business.Interfaces;

namespace Core.Web.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            foreach (var item in notificacoes)
            {
                ViewData.ModelState.AddModelError(string.Empty, item.Mensagem);
            }

            return View();
        }
    }
}