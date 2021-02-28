using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using records.Data;
using records.Models;

namespace records.Controllers
{
	public class CollectionController : Controller
	{
		private readonly CollectionContext _context;

		public CollectionController(CollectionContext context)
		{
			_context = context;
		}

		// GET: Collection
		public async Task<IActionResult> Index(string searchString)
		{
			var collection = from m in _context.Collection
			select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				collection = collection.Where(s => s.Title.ToLower().Contains(searchString.ToLower()) || s.ArtistName.ToLower().Contains(searchString.ToLower()));
			}
			return View(await collection.ToListAsync());
		}

		// GET: Collection/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collection = await _context.Collection
				.Include(c => c.Artist)
				.FirstOrDefaultAsync(m => m.CollectionId == id);
			if (collection == null)
			{
				return NotFound();
			}

			return View(collection);
		}

		// GET: Collection/Create
		public IActionResult Create()
		{
			ViewData["ArtistName"] = new SelectList(_context.Artist, "Name", "Name");
			return View();
		}

		// POST: Collection/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CollectionId,Title,ArtistName")] Collection collection)
		{
			if (ModelState.IsValid)
			{
				_context.Add(collection);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["ArtistName"] = new SelectList(_context.Artist, "Name", "Name", collection.ArtistName);
			return View(collection);
		}

		// GET: Collection/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collection = await _context.Collection.FindAsync(id);
			if (collection == null)
			{
				return NotFound();
			}
			ViewData["ArtistName"] = new SelectList(_context.Artist, "Name", "Name", collection.ArtistName);
			return View(collection);
		}

		// POST: Collection/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("CollectionId,Title,ArtistName")] Collection collection)
		{
			if (id != collection.CollectionId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(collection);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CollectionExists(collection.CollectionId))
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
			ViewData["ArtistName"] = new SelectList(_context.Artist, "Name", "Name", collection.ArtistName);
			return View(collection);
		}

		// GET: Collection/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collection = await _context.Collection
				.Include(c => c.Artist)
				.FirstOrDefaultAsync(m => m.CollectionId == id);
			if (collection == null)
			{
				return NotFound();
			}

			return View(collection);
		}

		// POST: Collection/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var collection = await _context.Collection.FindAsync(id);
			_context.Collection.Remove(collection);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CollectionExists(int id)
		{
			return _context.Collection.Any(e => e.CollectionId == id);
		}
	}
}
