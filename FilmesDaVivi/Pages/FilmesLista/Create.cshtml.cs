using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesDaVivi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesDaVivi.Pages.FilmesLista
{
    public class CreateModel : PageModel
    {
        private readonly Contexto _db;

        public CreateModel(Contexto db)
        {
            _db = db;
        }

        [BindProperty]
        public Filme Filmes { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Filmes.AddAsync(Filmes);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}