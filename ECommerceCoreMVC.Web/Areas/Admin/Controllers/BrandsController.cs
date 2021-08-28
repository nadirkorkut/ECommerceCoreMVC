using ECommerceCoreMVC.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerceCoreMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators,ProductAdministrators")]
    public class BrandsController : Controller
    {
        private readonly string entity = "Marka";
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public BrandsController(AppDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.OrderBy(p=>p.SortOrder).ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Brand { Enabled = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand model)
        {
            model.Date = DateTime.Now;
            model.UserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;

            var lastOrder = _context.Rayons.OrderByDescending(p => p.SortOrder).FirstOrDefault()?.SortOrder ?? 0;
            model.SortOrder = lastOrder + 1;

            if (model.PictureFile != null)
            {
                using (var image = Image.Load(model.PictureFile.OpenReadStream()))
                {
                    image.Mutate(p =>
                    {
                        p.Resize(new ResizeOptions
                        {
                            Size = new Size(200, 200),
                            Mode = ResizeMode.Crop,
                        })
                        .BackgroundColor(Color.White);

                    });
                    model.Image = image.ToBase64String(JpegFormat.Instance);
                }
            }

            _context.Entry(model).State = EntityState.Added;

            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} ekleme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"Aynı isimli birden fazla {entity.ToLower()} olamaz.";
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Brands.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Brand model)
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
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _context.Brands.FindAsync(id);

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
            var subject = await _context.Brands.FindAsync(id);
            var target = await _context.Brands.Where(p => p.SortOrder < subject.SortOrder).OrderBy(p => p.SortOrder).LastOrDefaultAsync();

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
            var subject = await _context.Brands.FindAsync(id);
            var target = await _context.Brands.Where(p => p.SortOrder > subject.SortOrder).OrderBy(p => p.SortOrder).FirstOrDefaultAsync();

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
    }
}
