using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMadMagic.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace MvcMadMagic.Controllers
{
    public class SpellsController : Controller
    {
        private readonly MadMagicContext _context;
        private HttpClient _client;
        private async Task<List<Spell>?> GetSpellsAsync()
        {
            return JsonConvert.DeserializeObject<List<Spell>?>(await (await _client.GetAsync(apiUrl + "logic/all")).Content.ReadAsStringAsync());
        }
        private string apiUrl = "http://localhost:5000/Spell/";

        public SpellsController(MadMagicContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
              return await GetSpellsAsync() != null ? 
                          View(await GetSpellsAsync()) :
                          Problem("Entity set 'MadMagicContext.Spell'  is null.");
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || GetSpellsAsync() == null)
            {
                return NotFound();
            }

            var spell = (await GetSpellsAsync())?
                .FirstOrDefault(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OnCast,MoveLogic,OnMove,OnHit,Speed,Bounce,Size,Charges,Visible,Type,PathToImage")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(spell);
                //await _context.SaveChangesAsync();
                await _client.PostAsync(apiUrl + "logic", new StringContent(JsonConvert.SerializeObject(spell).ToString(), Encoding.UTF8, "application/json"));
                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || await GetSpellsAsync() == null)
            {
                return NotFound();
            }

            var spell = (await GetSpellsAsync())?
                .FirstOrDefault(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,OnCast,MoveLogic,OnMove,OnHit,Speed,Bounce,Size,Charges,Visible,Type,PathToImage")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.PutAsync(apiUrl + "logic", new StringContent(JsonConvert.SerializeObject(spell).ToString(), Encoding.UTF8, "application/json"));
                    // _context.Update(spell);
                    // await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!await SpellExists(spell.Id))
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
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || await GetSpellsAsync() == null)
            {
                return NotFound();
            }

            var spell = (await GetSpellsAsync())?.FirstOrDefault(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (await GetSpellsAsync() == null)
            {
                return Problem("Cant Connect redis collection");
            }
            var spell = (await GetSpellsAsync())?
               .FirstOrDefault(m => m.Id == id);
            if (spell != null)
            {
                await _client.DeleteAsync(apiUrl + $"logic/{id}");
            }
            
            // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SpellExists(string id)
        {
          return ((await GetSpellsAsync())?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
