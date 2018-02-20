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
    public class DistritoController : Controller
    {
        private readonly PaiVContext _context;

        public DistritoController(PaiVContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<DistView> model = _context.Set<Distrito>().Include(d => d.Departamento).ToList().Select(s => new DistView
            {
               DistritoID = s.DistritoID,
                CodDistrito = s.CodDistrito,
                NDistrito = s.NDistrito,
                DepartamentoID = s.DepartamentoID,
                CodDepartamento = s.Departamento.CodDepartamento,
               NDepartamento = s.Departamento.NDepartamento,
           
            Estado = s.Estado
               
            });

            return View("Index", model);
        }
        [HttpGet]
        public IActionResult AddEditDist(int? id)
        {
            DistView model = new DistView();
            if (id.HasValue)
            {
                Distrito s = _context.Set<Distrito>().SingleOrDefault(c => c.DistritoID == id.Value);
                if (s != null)
                {
                    model.DistritoID = s.DistritoID;
                    model.CodDistrito = s.CodDistrito;
                    model.NDistrito = s.NDistrito;
                    model.DepartamentoID = s.DepartamentoID;
                    model.Estado = s.Estado;

                }
            }
            var query = from p in _context.Paises where p.Estado.Equals(true) select p;
            var query2 = from d in _context.Departamentos  where d.Estado.Equals(true) select d;
        

            ViewData["DepartamentoID"] = new SelectList(query2, "DepartamentoID", "NDepartamento");
            return PartialView("~/Views/Distrito/_AddEditDist.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditDist(int? id, DistView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Distrito dist = isNew ? new Distrito() : _context.Set<Distrito>().SingleOrDefault(s => s.DistritoID == id.Value);

                    dist.CodDistrito = model.CodDistrito;
                    dist.NDistrito = model.NDistrito;
                    dist.DepartamentoID = model.DepartamentoID;
                    dist.Estado = model.Estado;

                    if (isNew)
                    {
                        dist.Estado = true;
                        _context.Add(dist);
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
        public IActionResult DeleteDist(int id)
        {
            Distrito dist = _context.Set<Distrito>().SingleOrDefault(c => c.DistritoID == id);
            DistView model = new DistView
            {
                CodDistrito = dist.CodDistrito,
                NDistrito = dist.NDistrito,
                CodDepartamento = dist.Departamento.CodDepartamento,
                NDepartamento = dist.Departamento.NDepartamento,
                Estado = dist.Estado
            };
            return PartialView("~/Views/Distrito/_DelDist.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteDist(int id, IFormCollection form)
        {
            Distrito dist = _context.Set<Distrito>().SingleOrDefault(c => c.DistritoID == id);
            dist.Estado = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
