using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudGitFlowMVC.Data;
using CrudGitFlowMVC.Models;

namespace CrudGitFlowMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }


        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Nombre,Precio,Cantidad,Descripcion")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }



        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var producto = await _context.Productos.FindAsync(id);


            if (producto == null)
            {
                return NotFound();
            }


            return View(producto);
        }



        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Nombre,Precio,Cantidad,Descripcion")] Producto producto)
        {

            if (id != producto.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExiste(producto.Id))
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


            return View(producto);
        }




        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);


            if (producto == null)
            {
                return NotFound();
            }


            return View(producto);
        }




        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producto = await _context.Productos.FindAsync(id);


            if (producto != null)
            {
                _context.Productos.Remove(producto);

                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }



        private bool ProductoExiste(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }

    }
}