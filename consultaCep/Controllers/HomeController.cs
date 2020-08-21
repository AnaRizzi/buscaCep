using consultaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consultaCep.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Endereco endereco)
        {
            var ws = new correio.AtendeClienteClient();

            ModelState.Remove("Rua");
            ModelState.Remove("Bairro");
            ModelState.Remove("Cidade");
            ModelState.Remove("Estado");

            try
            {
                var enderecoCompleto = ws.consultaCEP(endereco.Cep);

                endereco.Rua = enderecoCompleto.end;
                endereco.Bairro = enderecoCompleto.bairro;
                endereco.Cidade = enderecoCompleto.cidade;
                endereco.Estado = enderecoCompleto.uf;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("cep", "Cep não encontrado");
            }

            if (ModelState.IsValid)
            {
                return View(endereco);
            }
            else
            {
                endereco.Rua = "";
                endereco.Bairro = "";
                endereco.Cidade = "";
                endereco.Estado = "";

                return View(endereco);
            }
        }


    }
}