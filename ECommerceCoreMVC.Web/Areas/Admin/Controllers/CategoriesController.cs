using ECommerceCoreMVC.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators,ProductAdministrators")]
    public class CategoriesController : Controller
    {
        private readonly string entity = "Kategori";
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public CategoriesController(AppDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.OrderBy(p=>p.SortOrder).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropDowns();
            return View(new Category { Enabled = true });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            model.Date = DateTime.Now;
            model.UserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;

            var lastOrder = _context.Categories.OrderByDescending(p => p.SortOrder).FirstOrDefault()?.SortOrder ?? 0;
            model.SortOrder = lastOrder + 1;

            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} Ekleme İşlemi Başarıyla Tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"Aynı İsimli Birden Fazla {entity.ToLower()} Olamaz.";
                await PopulateDropDowns();
                return View(model);
            } 
        }

        public async Task<IActionResult> Edit(int id)
        {
            await PopulateDropDowns();
            return View(await _context.Categories.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            model.UserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;

            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} Güncelleme İşlemi Başarıyla Tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"Aynı İsimli Birden Fazla {entity.ToLower()} Olamaz.";
                await PopulateDropDowns();
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _context.Categories.FindAsync(id);

            _context.Entry(model).State = EntityState.Deleted;
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} Silme İşlemi Başarıyla Tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{model.Name} İsimli {entity.ToLower()}, Bir Yada Daha Fazla Kayıtla İlişkili Olduğu için Silinemiyor...";
                return View(model);
            }
        }

        public async Task<IActionResult> MoveUp(int id)
        {
            var subject = await _context.Categories.FindAsync(id);
            var target = await _context.Categories.Where(p => p.RayonId == subject.RayonId && p.SortOrder < subject.SortOrder).OrderBy(p => p.SortOrder).LastOrDefaultAsync();

            if (target != null)
            {
                var m = subject.SortOrder;
                subject.SortOrder = target.SortOrder;
                target.SortOrder = m;

                _context.Entry(subject).State = EntityState.Modified;
                _context.Entry(target).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} Sıralamada Yukarıya Alındı";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownUp(int id)
        {
            var subject = await _context.Categories.FindAsync(id);
            var target = await _context.Categories.Where(p => p.RayonId == subject.RayonId && p.SortOrder > subject.SortOrder).OrderBy(p => p.SortOrder).FirstOrDefaultAsync();

            if (target != null)
            {
                var m = subject.SortOrder;
                subject.SortOrder = target.SortOrder;
                target.SortOrder = m;

                _context.Entry(subject).State = EntityState.Modified;
                _context.Entry(target).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} Sıralamada Aşağıya Alındı";
            }
            return RedirectToAction("Index");
        }

        private async Task PopulateDropDowns()
        {
            ViewBag.Rayons = new SelectList(await _context.Rayons.OrderBy(p => p.Name).ToListAsync(), "Id", "Name");
        }
    }
}
