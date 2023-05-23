using Microsoft.AspNetCore.Mvc;
using MvcAWSPostgresEC2.Models;
using MvcAWSPostgresEC2.Repositories;

namespace MvcAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departs = await this.repo.GetDepartsAsync();
            return View(departs);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento depart = await this.repo.FindDepartAsync(id);
            return View(depart);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento depart)
        {
            await this.repo.InsertarDepartAsync(depart.IdDepartamento, depart.Nombre, depart.Localidad);
            return RedirectToAction("Index");
        }
    }
}
