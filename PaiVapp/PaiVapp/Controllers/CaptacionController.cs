using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiVapp.Data;
using PaiVapp.Models;

namespace PaiVapp.Controllers
{
    public class CaptacionController : Controller
    {
        private readonly PaiVContext _context;

        public CaptacionController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Captacion
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.Captaciones.Include(c => c.Departamento).Include(c => c.Distrito).Include(c => c.Pais);
            return View(await paiVContext.ToListAsync());
        }

        // GET: Captacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captacion = await _context.Captaciones
                .Include(c => c.Departamento)
                .Include(c => c.Distrito)
                .Include(c => c.Pais)
                .SingleOrDefaultAsync(m => m.CaptacionID == id);
            if (captacion == null)
            {
                return NotFound();
            }

            return View(captacion);
        }

        // GET: Captacion/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento");
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito");
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais");
            return View();
        }

        // POST: Captacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaptacionID,CI,CICod,RegNacimiento,PNombre,SNombre,TNombre,PApellido,SApellido,FNacimiento,Sexo,PaisID,CIMadre,NomApMadre,EmailMadre,CIPadreT,NomApPadre,EmailPT,DepartamentoID,DistritoID,Barrio,Direccion,ReferenciaDir,Telefono,Localidad,ComIndigena,TComIndigena,AlergiaSN,AlergVacuna,AlerMedic,AlergOtros,DescOtros,EstadoNut,Pani,LacMaterna,SegMedico,TSeguro,DSeguro")] Captacion captacion)
        {
            if (ModelState.IsValid)
            {
                captacion.Estado = true;
                _context.Add(captacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", captacion.DepartamentoID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", captacion.DistritoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", captacion.PaisID);
            return View(captacion);
        }

        // GET: Captacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captacion = await _context.Captaciones.SingleOrDefaultAsync(m => m.CaptacionID == id);
            if (captacion == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", captacion.DepartamentoID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", captacion.DistritoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", captacion.PaisID);
            return View(captacion);
        }

        // POST: Captacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaptacionID,CI,CICod,RegNacimiento,PNombre,SNombre,TNombre,PApellido,SApellido,FNacimiento,Sexo,PaisID,CIMadre,NomApMadre,EmailMadre,CIPadreT,NomApPadre,EmailPT,DepartamentoID,DistritoID,Barrio,Direccion,ReferenciaDir,Telefono,Localidad,ComIndigena,TComIndigena,AlergiaSN,AlergVacuna,AlerMedic,AlergOtros,DescOtros,EstadoNut,Pani,LacMaterna,SegMedico,TSeguro,DSeguro")] Captacion captacion)
        {
            if (id != captacion.CaptacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(captacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaptacionExists(captacion.CaptacionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", captacion.DepartamentoID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", captacion.DistritoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", captacion.PaisID);
            return View(captacion);
        }

        // GET: Captacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var captacion = await _context.Captaciones
                .Include(c => c.Departamento)
                .Include(c => c.Distrito)
                .Include(c => c.Pais)
                .SingleOrDefaultAsync(m => m.CaptacionID == id);
            if (captacion == null)
            {
                return NotFound();
            }

            return View(captacion);
        }

        // POST: Captacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var captacion = await _context.Captaciones.SingleOrDefaultAsync(m => m.CaptacionID == id);
            captacion.Estado = false;
            _context.Captaciones.Update(captacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaptacionExists(int id)
        {
            return _context.Captaciones.Any(e => e.CaptacionID == id);
        }
    }
}
