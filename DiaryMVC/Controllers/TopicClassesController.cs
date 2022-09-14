using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiaryMVC.Data;
using DiaryMVC.Models;

namespace DiaryMVC.Controllers
{
    public class TopicClassesController : Controller
    {
        private readonly DiaryMVCContext _context;

        public TopicClassesController(DiaryMVCContext context)
        {
            _context = context;
        }
       
        // GET: TopicClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopicClass.ToListAsync());
        }

        // GET: TopicClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicClass == null)
            {
                return NotFound();
            }

            return View(topicClass);
        }

        // GET: TopicClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopicClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TimeToMaster,TimeSpent,Source,StartLearningDate,InProgress")] TopicClass topicClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topicClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topicClass);
        }

        // GET: TopicClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClass.FindAsync(id);
            if (topicClass == null)
            {
                return NotFound();
            }
            return View(topicClass);
        }

        // POST: TopicClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TimeToMaster,TimeSpent,Source,StartLearningDate,InProgress")] TopicClass topicClass)
        {
            if (id != topicClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topicClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicClassExists(topicClass.Id))
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
            return View(topicClass);
        }

        // GET: TopicClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicClass == null)
            {
                return NotFound();
            }

            return View(topicClass);
        }

        // POST: TopicClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicClass = await _context.TopicClass.FindAsync(id);
            _context.TopicClass.Remove(topicClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicClassExists(int id)
        {
            return _context.TopicClass.Any(e => e.Id == id);
        }
    }
}
