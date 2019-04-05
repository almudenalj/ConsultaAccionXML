using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaAccionXML.Models;
using ConsultaAccionXML.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAccionXML.Controllers
{
    public class CaballosXMLController : Controller
    {
        IRepositoryCaballos repo;

        public CaballosXMLController(IRepositoryCaballos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetCaballos());

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Caballo caballo)
        {
            this.repo.InsertarCaballo(caballo.IdCaballo, caballo.Nombre
                , caballo.Nivel, caballo.Edad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idcaballo)
        {
            this.repo.EliminarCaballo(idcaballo);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int idcaballo)
        {
            Caballo caballo = this.repo.BuscarCaballo(idcaballo);
            return View(caballo);
        }


    }
}