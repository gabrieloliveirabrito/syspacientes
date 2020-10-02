using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pacientesPessoas.Models;

namespace pacientesPessoas.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ILogger<PacientesController> logger;

        public PacientesController(ILogger<PacientesController> logger){
            this.logger = logger;
        }

        public IActionResult Index(){
             //criar uma lista de pacientes:
            var listaPacientes = new List<Pacientes>(){
                new Pacientes(1,5,"01/09/2020","Teste1",1),
                new Pacientes(2,6,"02/09/2020","Teste2",2),
                new Pacientes(3,7,"03/09/2020","Teste3",3),
                new Pacientes(4,8,"04/09/2020","Teste4",4),
                new Pacientes(5,9,"05/09/2020","Teste5",5),
            };
            return View(listaPacientes);
        }

        public IActionResult Editar(){
            return View();
        }

        public IActionResult Excluir(){
            return View();
        }

        
         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}