using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModels = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemsModels == null)
            {
                return NotFound();
            }

            return View(itemsModels);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemName,ItemDescription,Depcode,InternalCode,HSNCode,AccountsHead,OEM1,OEM2,BinNumber,StoreRoomNumber,UOM,MinimumQuantity,AvailableQuantity,itemprice,Totalvalueofitem,Date")] ItemsModels itemsModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemsModels);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModels = await _context.Items.FindAsync(id);
            if (itemsModels == null)
            {
                return NotFound();
            }
            return View(itemsModels);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemName,ItemDescription,Depcode,InternalCode,HSNCode,AccountsHead,OEM1,OEM2,BinNumber,StoreRoomNumber,UOM,MinimumQuantity,AvailableQuantity,itemprice,Totalvalueofitem,Date")] ItemsModels itemsModels)
        {
            if (id != itemsModels.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsModelsExists(itemsModels.ID))
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
            return View(itemsModels);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsModels = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemsModels == null)
            {
                return NotFound();
            }

            return View(itemsModels);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemsModels = await _context.Items.FindAsync(id);
            _context.Items.Remove(itemsModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsModelsExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
