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
    public class PaisController : Controller
    {
        private readonly PaiVContext _context;

        public PaisController(PaiVContext context)
        {
            _context = context;
        }
        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.PaisID == id);
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<PaisView> model = _context.Set<Pais>().ToList().Select(s => new PaisView
            {
                PaisID = s.PaisID,
                NPais = s.NPais,
                Nacionalidad = s.Nacionalidad,
                Estado = s.Estado

            });
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult AddEditPais(int? id)
        {
            PaisView model = new PaisView();
            if (id.HasValue)
            {
                Pais pais = _context.Set<Pais>().SingleOrDefault(c => c.PaisID == id.Value);
                if (pais != null)
                {
                    model.PaisID = pais.PaisID;
                    model.NPais = pais.NPais;
                    model.Nacionalidad = pais.Nacionalidad;
                    model.Estado = pais.Estado;

                }
            }
            return PartialView("~/Views/Pais/_AddEditPais.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditPais(int? id, PaisView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Pais pais = isNew ? new Pais() : _context.Set<Pais>().SingleOrDefault(s => s.PaisID == id.Value);
                    pais.NPais = model.NPais;
                    pais.Nacionalidad = model.Nacionalidad;
                    pais.Estado = model.Estado;

                    if (isNew)
                    {
                        pais.Estado = true;
                        _context.Add(pais);
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
        public IActionResult DeletePais(int id)
        {
            Pais pais = _context.Set<Pais>().SingleOrDefault(c => c.PaisID == id);
            PaisView model = new PaisView
            {
                PaisID = pais.PaisID,
                NPais = pais.NPais,
                Nacionalidad = pais.Nacionalidad,
                Estado = pais.Estado
            };
            return PartialView("~/Views/Pais/_DeletePais.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeletePais(int id, IFormCollection form)
        {

            Pais pais = _context.Set<Pais>().SingleOrDefault(s => s.PaisID == id);
          //  Pais pais = _context.Set<Pais>().SingleOrDefault(c => c.PaisID == id);
            pais.Estado = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
         
        }

      

    }
}
