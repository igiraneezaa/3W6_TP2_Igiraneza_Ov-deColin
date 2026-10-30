
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.Data;

public class CategoriesController : Controller
{
    private readonly NutrieVieDbContext _context;

    public CategoriesController(NutrieVieDbContext context)
    {
        _context = context;
    }

    // GET: CATEGORIES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Categories.ToListAsync());
    }

    // GET: CATEGORIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // GET: CATEGORIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CATEGORIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Recettes")] Categorie categorie)
    {
        bool existeDeja = await _context.Categories
         .AnyAsync(c => c.Nom.ToLower() == categorie.Nom.ToLower());

        if (existeDeja)
        {
            ModelState.AddModelError("Nom", "Cette catégorie existe déjà");
        }

        if (ModelState.IsValid)
        {
            _context.Add(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categorie);
    }

    // GET: CATEGORIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null)
        {
            return NotFound();
        }
        return View(categorie);
    }

    // POST: CATEGORIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Recettes")] Categorie categorie)
    {
        if (id != categorie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categorie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(categorie.Id))
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
        return View(categorie);
    }

    // GET: CATEGORIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // POST: CATEGORIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var categorie = await _context.Categories
        .Include(c => c.Recettes)
        .FirstOrDefaultAsync(c => c.Id == id);

        if (categorie == null)
        {
            return NotFound();
        }

        // Vérifier si la catégorie contient des recettes
        if (categorie.Recettes != null && categorie.Recettes.Any())
        {
            ModelState.AddModelError(string.Empty, "Vous ne pouvez supprimer cette catégorie parce qu'elle contient des recettes");
            return View(categorie);
        }

        _context.Categories.Remove(categorie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategorieExists(int? id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
