using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TesteCandidato1.Context;
using TesteCandidato1.Models.DTOs;
using TesteCandidato1.Models;
using TesteCandidato1.Services;
using TesteCandidato1.Controls;

namespace TesteCandidato1.Pages
{
    public class ConsultaCEPModel : PageModel
    {
        private readonly CepContext _context;
        public ConsultaCEPModel(CepContext context)
        {
            _context = context;
        }

        public Cep CepInfo { get; set; }
        [TempData]
        public string MensagemErro { get; set; }

        public async Task<IActionResult> OnGet(string cep)
        {
            if (!String.IsNullOrEmpty(cep))
            {
                cep = cep?.Replace(".", "").Replace("-", "");

                MensagemErro = string.Empty;
                CepInfo = _context.Ceps.Where(c => c.Cep1 == cep).FirstOrDefault();

                if (CepInfo == null)
                {
                    var dadosConsultaCEP = await new CepService().RecuperarDadosCep(cep);

                    if (dadosConsultaCEP.Cep == null)
                    {
                        MensagemErro = "CEP não encontrado ou inválido.";

                        return Page();
                    }

                    CepInfo = await new CepControl(_context).PersistirCep(dadosConsultaCEP);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string cepInformado)
        {
            return RedirectToPage("./ConsultaCEP", new { cep = cepInformado });
        }
    }
}
