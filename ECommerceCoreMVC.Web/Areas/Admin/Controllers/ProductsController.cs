using ECommerceCoreMVC.Data.Entities;
using ECommerceCoreMVC.Web.Areas.Admin.Models.DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.Globalization;

namespace ECommerceCoreMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators,ProductAdministrators")]
    public class ProductsController : Controller
    {
        private readonly string entity = "Ürün";
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        public ProductsController(AppDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> List(Parameters parameters)
        {

            var query = _context.Products.AsQueryable();
            foreach (var order in parameters.Order)
            {
                switch (parameters.Columns[order.Column].Data)
                {
                    case "name":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                        break;
                    case "date":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.Date) : query.OrderByDescending(p => p.Date);
                        break;
                    case "enabled":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.Enabled) : query.OrderByDescending(p => p.Enabled);
                        break;
                    case "userName":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.User.Name) : query.OrderByDescending(p => p.User.Name);
                        break;
                    case "price":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                        break;
                    case "reviews":
                        query = order.Dir == OrderDir.ASC ? query.OrderBy(p => p.Reviews) : query.OrderByDescending(p => p.Reviews);
                        break;
                    default:
                        break;
                }
            }

            var data = await query.Skip(parameters.Start).Take(parameters.Length).Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Picture = p.Image ?? "/content/images/no-image.png",
                Name = p.Name,
                Date = p.Date.ToShortDateString(),
                Enabled = p.Enabled,
                Price = p.Price.ToString("c2"),
                Reviews = p.Reviews.ToString("n0"),
                UserName = p.User.Name,
                Categories = string.Join(", ", p.CategoryProducts.Select(q => $"{q.Category.Rayon.Name}/{q.Category.Name}")),
                BrandName = p.Brand.Name,
                Barcode = p.Barcode,
                ProductCode = p.ProductCode
            }).ToListAsync();

            var recordsFiltered = await query.CountAsync();
            var recordsTotal = await _context.Products.CountAsync();

            var result = new Result<ProductListViewModel>
            {
                data = data,
                draw = parameters.Draw,
                recordsFiltered = recordsFiltered,
                recordsTotal = recordsTotal
            };

            return Json(result);
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View(new Product { Enabled = true });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            model.Date = DateTime.Now;
            model.UserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;

            if (model.PictureFile != null)
            {
                using (var image = Image.Load(model.PictureFile.OpenReadStream()))
                {
                    image.Mutate(p =>
                    {
                        p.Resize(new ResizeOptions
                        {
                            Size = new Size(800, 800),
                            Mode = ResizeMode.Crop
                        })
                        .BackgroundColor(Color.White);
                    });
                    model.Image = image.ToBase64String(JpegFormat.Instance);
                }
            }

            if (model.PictureFiles != null)
            {
                foreach (var pictureFile in model.PictureFiles)
                {
                    using (var image = Image.Load(pictureFile.OpenReadStream()))
                    {
                        image.Mutate(p =>
                        {
                            p.Resize(new ResizeOptions
                            {
                                Size = new Size(800, 800),
                                Mode = ResizeMode.Crop
                            })
                            .BackgroundColor(Color.White);
                        });
                        var picture = image.ToBase64String(JpegFormat.Instance);
                        var productPicture = new ProductImage
                        {
                            Date = DateTime.Now,
                            Enabled = true,
                            Image = picture,
                            UserId = model.UserId
                        };
                        model.ProductImages.Add(productPicture);
                        _context.Entry(productPicture).State = EntityState.Added;
                    }
                }
            }

            model.Price = decimal.Parse(model.PriceText, CultureInfo.CreateSpecificCulture("tr-TR"));

            if (model.SelectedCategories != null)
            {
                model.SelectedCategories
                    .ToList()
                    .ForEach(p =>
                    {
                        var categoryProduct = new CategoryProduct { CategoryId = p };
                        model.CategoryProducts.Add(categoryProduct);
                        _context.Entry(categoryProduct).State = EntityState.Added;
                    });
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
                await PopulateDropdowns();
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            await PopulateDropdowns();
            var model = await _context.Products.FindAsync(id);
            model.PriceText = model.Price.ToString("f2");
            model.SelectedCategories = model.CategoryProducts.Select(p => p.CategoryId).ToArray();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product model)
        {
            model.UserId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;

            if (model.PictureFile != null)
            {
                using (var image = Image.Load(model.PictureFile.OpenReadStream()))
                {
                    image.Mutate(p =>
                    {
                        p.Resize(new ResizeOptions
                        {
                            Size = new Size(800, 800),
                            Mode = ResizeMode.Crop
                        })
                        .BackgroundColor(Color.White);
                    });
                    model.Image = image.ToBase64String(JpegFormat.Instance);
                }
            }

            if (model.PictureFiles != null)
            {
                foreach (var pictureFile in model.PictureFiles)
                {
                    using (var image = Image.Load(pictureFile.OpenReadStream()))
                    {
                        image.Mutate(p =>
                        {
                            p.Resize(new ResizeOptions
                            {
                                Size = new Size(800, 800),
                                Mode = ResizeMode.Crop
                            })
                            .BackgroundColor(Color.White);
                        });
                        var picture = image.ToBase64String(JpegFormat.Instance);
                        var productPicture = new ProductImage
                        {
                            Date = DateTime.Now,
                            Enabled = true,
                            Image = picture,
                            UserId = model.UserId
                        };
                        model.ProductImages.Add(productPicture);
                        _context.Entry(productPicture).State = EntityState.Added;
                    }
                }
            }

            if (model.PictureFilesToDeleted != null)
            {
                foreach (var pictureFileId in model.PictureFilesToDeleted)
                {
                    var pictureFile = await _context.ProductImages.FindAsync(pictureFileId);
                    _context.Entry(pictureFile).State = EntityState.Deleted;
                }
            }

            model.Price = decimal.Parse(model.PriceText, CultureInfo.CreateSpecificCulture("tr-TR"));

            var currentCategories = await _context.CategoryProducts.Where(p => p.ProductId == model.Id).Select(p => p.CategoryId).ToArrayAsync();

            if (model.SelectedCategories != null)
            {
                model.SelectedCategories
                    .ToList()
                    .ForEach(p =>
                    {
                        if (!currentCategories.Any(q => q == p))
                        {
                            var categoryProduct = new CategoryProduct { CategoryId = p };
                            model.CategoryProducts.Add(categoryProduct);
                            _context.Entry(categoryProduct).State = EntityState.Added;
                        }
                    });

                currentCategories
                    .Except(model.SelectedCategories)
                    .ToList()
                    .ForEach(p =>
                    {
                        var categoryProduct = _context.CategoryProducts.SingleOrDefault(q => q.ProductId == model.Id && q.CategoryId == p);
                        _context.Entry(categoryProduct).State = EntityState.Deleted;
                    });

            }

            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} güncelleme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"Aynı isimli birden fazla {entity.ToLower()} olamaz.";
                await PopulateDropdowns();
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            var model = await _context.Products.FindAsync(id);

            _context.Entry(model).State = EntityState.Deleted;
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = $"{entity} silme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{model.Name} isimli {entity.ToLower()}, bir ya da daha fazla kayıt ile ilişkili olduğu için silme işlemi tamamlanamıyor.";
                return View(model);
            }
        }

        private async Task PopulateDropdowns()
        {
            ViewBag.Brands = new SelectList(await _context.Brands.OrderBy(p => p.Name).ToListAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _context.Categories.OrderBy(p => p.Name).Select(p => new { p.Id, p.Name, RayonName = p.Rayon.Name }).ToListAsync(), "Id", "Name", null, "RayonName");
        }
    }
}
