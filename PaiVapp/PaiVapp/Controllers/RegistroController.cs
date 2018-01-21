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
    public class RegistroController : Controller
    {
        private readonly PaiVContext _context;

        public RegistroController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Registro
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.Registros.Include(r => r.Captacion).Include(r => r.DosisBiologico);
            return View(await paiVContext.ToListAsync());
        }

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Captacion)
                .Include(r => r.DosisBiologico)
                .SingleOrDefaultAsync(m => m.RegistroID == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registro/Create
        public IActionResult Create()
        {
           
            ViewData["CaptacionID"] = new SelectList(_context.Captaciones, "CaptacionID", "CICod");
            ViewData["Biologico"] = new SelectList(_context.Biologicos, "BiologicoID", "NBiologico");
            ViewData["DosisBiologicoID"] = new SelectList(_context.DosisBiologicos, "DosisBiologicoID", "Dosis");
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroID,FechaV,CaptacionID,DosisBiologicoID,Lote,Encargado")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                registro.Estado = true;
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaptacionID"] = new SelectList(_context.Captaciones, "CaptacionID", "CICod", registro.CaptacionID);
            ViewData["DosisBiologicoID"] = new SelectList(_context.DosisBiologicos, "DosisBiologicoID", "Dosis", registro.DosisBiologicoID);
            ViewData["Biologico"] = new SelectList(_context.Biologicos, "BiologicoID", "NBiologico");
            return View(registro);
        }

        // GET: Registro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.SingleOrDefaultAsync(m => m.RegistroID == id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["CaptacionID"] = new SelectList(_context.Captaciones, "CaptacionID", "CICod", registro.CaptacionID);
            ViewData["DosisBiologicoID"] = new SelectList(_context.DosisBiologicos, "DosisBiologicoID", "Dosis", registro.DosisBiologicoID);
            ViewData["Biologico"] = new SelectList(_context.Biologicos, "BiologicoID", "NBiologico");
            return View(registro);
        }

        // POST: Registro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroID,FechaV,CaptacionID,DosisBiologicoID,Lote,Encargado")] Registro registro)
        {
            if (id != registro.RegistroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.RegistroID))
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
            ViewData["CaptacionID"] = new SelectList(_context.Captaciones, "CaptacionID", "CICod", registro.CaptacionID);
            ViewData["DosisBiologicoID"] = new SelectList(_context.DosisBiologicos, "DosisBiologicoID", "Dosis", registro.DosisBiologicoID);
            ViewData["Biologico"] = new SelectList(_context.Biologicos, "BiologicoID", "NBiologico");
            return View(registro);
        }

        // GET: Registro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Captacion)
                .Include(r => r.DosisBiologico)
                .SingleOrDefaultAsync(m => m.RegistroID == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registros.SingleOrDefaultAsync(m => m.RegistroID == id);
            registro.Estado = false;
            _context.Registros.Update(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.RegistroID == id);
        }
    }
}
