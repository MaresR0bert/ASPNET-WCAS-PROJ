using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISM_MaresRobertDorian_ASPNETPROJWCAS.Data;
using ISM_MaresRobertDorian_ASPNETPROJWCAS.Models;
using Microsoft.AspNetCore.Authorization;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL Games
        public async Task<IActionResult> Index()
        {
              return _context.Games != null ? 
                          View(await _context.Games.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Games'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        //CREATE Game
        //[Authorize(Roles = "ADMIN_ROLE")]
        public IActionResult Create()
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            return View();
        }

        //CREATE Game
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN_ROLE")]
        public async Task<IActionResult> Create([Bind("Id,Name,Publisher,GameSize,ImgString,ReleaseDate")] Game game)
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        //UPDATE Game
        //[Authorize(Roles = "ADMIN_ROLE")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        //UPDATE Game
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN_ROLE")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Publisher,GameSize,ImgString,ReleaseDate")] Game game)
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        //DELETE Game
        //[Authorize(Roles = "ADMIN_ROLE")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        //DELETE Game
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ADMIN_ROLE")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!User.IsInRole("ADMIN_ROLE"))
            {
                return Unauthorized("Acces denied! You are not an Admin!");
            }
            if (_context.Games == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Games'  is null.");
            }
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
