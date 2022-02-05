#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bertozzi.mattia._5H.WebCRUD.Models;

namespace bertozzi.mattia._5H.WebCRUD.Controllers
{
    public class MoviesController : Controller
    {
        private readonly WebCRUDContext db;

        public MoviesController(WebCRUDContext context)
        {
            db = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await db.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();// 404 Not found
            }

            var movie = await db.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)

        //VERSIONE ASYNC
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create( Movie movie ) //IL BIND NON é NECESSARIO
        // {
        //     if (ModelState.IsValid)
        //     {
        //         //db.Add(movie);
        //         db.Movie.Add(movie);
        //         await db.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(movie);
        // }

        //VERSIONE NON ASYNC
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Movie movie ) //IL BIND NON é NECESSARIO
        {

            if (ModelState.IsValid)
            {
                db.Movie.Add(movie);
                db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }        
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(movie);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await db.Movie.FindAsync(id);
            db.Movie.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return db.Movie.Any(e => e.Id == id);
        }
    }
}
