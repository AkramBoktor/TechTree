using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechTreeMVCWebApplication.Data;
using TechTreeMVCWebApplication.Entities;

namespace TechTreeMVCWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Admin/Contents/Create
        public IActionResult Create(int categoryItemId , int categoryId)
        {
            Content content = new Content
            {
                CategoryId = categoryId,
                CatItemId = categoryItemId
            };
            return View(content);
        }

        // POST: Admin/Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,HtmlContent,VideoLink,CategoryId,CatItemId")] Content content)
        {
            if (ModelState.IsValid)
            {
                content.CategoryItem  = await _context.CategoryItem.FindAsync(content.CatItemId);
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"CategoryItem",new { categoryId = content.CategoryId});
            }
            return View(content);
        }

        // GET: Admin/Contents/Edit/5
        public async Task<IActionResult> Edit(int categoryItemId, int categoryId)
        {
            if (categoryItemId == 0)
            {
                return NotFound();
            }

            var content = await _context.Content.SingleOrDefaultAsync(item => item.CategoryItem.Id == categoryItemId);
            if (content == null)
            {
                return NotFound();
            }
            content.CategoryId = categoryId;
            return View(content);
        }

        // POST: Admin/Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,HtmlContent,VideoLink,CategoryId")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "CategoryItem", new { categoryId = content.CategoryId });
            }
            return View(content);
        }

      


        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.Id == id);
        }
    }
}
