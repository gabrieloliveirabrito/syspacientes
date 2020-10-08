using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using pacientesPessoas.Models;

namespace pacientesPessoas.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ILogger<PacientesController> logger;
        private readonly IHttpClientFactory clientFactory;

        public PacientesController(ILogger<PacientesController> logger, IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
               "https://localhost:5001/api/pacientes");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var listaPacientes = JsonConvert.DeserializeObject<List<Pacientes>>(json);

                return View(listaPacientes);
            }
            else
            {
                return this.Error();
            }
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}