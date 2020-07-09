using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesDaVivi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmesDaVivi.Pages.FilmesLista
{
    public class IndexModel : PageModel
    {
        private readonly Contexto _db;

        public IndexModel(Contexto db)
        {
            _db = db;
        }

        public IEnumerable<Filme> Filmes { get; set; }

        public async Task OnGet()
        {
            Filmes = await _db.Filmes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var filmeDB = await _db.Filmes.FindAsync(id);
            if(filmeDB == null)
            {
                return NotFound();
            }
            _db.Filmes.Remove(filmeDB);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}