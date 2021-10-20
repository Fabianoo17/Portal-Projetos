using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("")]
        [Route("500")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View("NotFound");
        }

        [Route("401")]
        [Route("403")]
        public IActionResult AccessDenied(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}