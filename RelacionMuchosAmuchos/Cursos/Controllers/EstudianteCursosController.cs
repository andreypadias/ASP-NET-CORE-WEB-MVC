using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cursos.Data;
using Cursos.Models;

namespace Cursos.Controllers
{
    public class EstudianteCursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudianteCursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstudianteCursos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EstudiantesCursos.Include(e => e.Curso).Include(e => e.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EstudianteCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteCurso = await _context.EstudiantesCursos
                .Include(e => e.Curso)
                .Include(e => e.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return View(estudianteCurso);
        }

        // GET: EstudianteCursos/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id");
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: EstudianteCursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEstudiante,IdCurso")] EstudianteCurso estudianteCurso)
        {
            try
            {
                _context.Add(estudianteCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", estudianteCurso.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Id", estudianteCurso.IdEstudiante);
            return View(estudianteCurso);
        }

        // GET: EstudianteCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteCurso = await _context.EstudiantesCursos.FindAsync(id);
            if (estudianteCurso == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", estudianteCurso.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Id", estudianteCurso.IdEstudiante);
            return View(estudianteCurso);
        }

        // POST: EstudianteCursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEstudiante,IdCurso")] EstudianteCurso estudianteCurso)
        {
            if (id != estudianteCurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteCursoExists(estudianteCurso.Id))
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
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", estudianteCurso.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Id", estudianteCurso.IdEstudiante);
            return View(estudianteCurso);
        }

        // GET: EstudianteCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteCurso = await _context.EstudiantesCursos
                .Include(e => e.Curso)
                .Include(e => e.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return View(estudianteCurso);
        }

        // POST: EstudianteCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteCurso = await _context.EstudiantesCursos.FindAsync(id);
            if (estudianteCurso != null)
            {
                _context.EstudiantesCursos.Remove(estudianteCurso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteCursoExists(int id)
        {
            return _context.EstudiantesCursos.Any(e => e.Id == id);
        }
    }
}
