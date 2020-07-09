using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesDaVivi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesDaVivi.Pages.FilmesLista
{
    public class EditModel : PageModel
    {
        private Contexto _db;

        public EditModel(Contexto db)
        {
            _db = db;
        }

        [BindProperty]
        public Filme Filmes { get; set; }

        public async Task OnGet(int id)
        {
            Filmes = await _db.Filmes.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var FilmeDB = await _db.Filmes.FindAsync(Filmes.Id);
                FilmeDB.Titulo = Filmes.Titulo;
                FilmeDB.Genero = Filmes.Genero;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}