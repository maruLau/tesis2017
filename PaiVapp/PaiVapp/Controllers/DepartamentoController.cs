using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiVapp.Data;
using PaiVapp.Models;
using PaiVapp.Models.Views;

namespace PaiVapp.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly PaiVContext _context;

        public DepartamentoController(PaiVContext context)
        {
            _context = context;
        }
        
        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<DptoView> model = _context.Set<Departamento>().Include(p => p.Pais).ToList().Select(s => new DptoView
            {
                DepartamentoID = s.DepartamentoID,
                CodDeparamento = s.CodDepartamento,
                NDepartamento =s.NDepartamento,
                PaisID = s.PaisID,
                NPais = s.Pais.NPais,
                Estado = s.Estado

            });
           
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult AddEditDpto(int? id)
        {
            DptoView model = new DptoView();
            if (id.HasValue)
            {
                Departamento s = _context.Set<Departamento>().SingleOrDefault(c => c.DepartamentoID == id.Value);
                if (s != null)
                {
                    model.DepartamentoID = s.DepartamentoID;
                    model.CodDeparamento = s.CodDepartamento;
                    model.NDepartamento = s.NDepartamento;
                    model.PaisID = s.PaisID;
                   // model.NPais = s.Pais.NPais;
                    model.Estado = s.Estado;

                }
            }
            var query = from p in _context.Paises where p.Estado.Equals(true) select p;
           
            ViewData["PaisID"] = new SelectList(query, "PaisID","NPais");
            return PartialView("~/Views/Departamento/_AddEditDpto.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditDpto(int? id, DptoView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Departamento dpto = isNew ? new Departamento() : _context.Set<Departamento>().SingleOrDefault(s => s.DepartamentoID == id.Value);
                    
                    dpto.CodDepartamento = model.CodDeparamento;
                    dpto.NDepartamento = model.NDepartamento;
                    dpto.PaisID = model.PaisID;

                    dpto.Estado = model.Estado;

                    if (isNew)
                    {
                        dpto.Estado = true;
                        _context.Add(dpto);
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteDpto(int id)
        {
            Departamento dpto = _context.Set<Departamento>().SingleOrDefault(c => c.DepartamentoID == id);
            DptoView model = new DptoView
            {
                CodDeparamento = dpto.CodDepartamento,
                NDepartamento = dpto.NDepartamento,
                PaisID = dpto.PaisID,
                Estado = dpto.Estado
            };
            return PartialView("~/Views/Departamento/_DelDpto.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteDpto(int id, IFormCollection form)
        {
            Departamento dpto = _context.Set<Departamento>().SingleOrDefault(c => c.DepartamentoID == id);
            dpto.Estado = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
