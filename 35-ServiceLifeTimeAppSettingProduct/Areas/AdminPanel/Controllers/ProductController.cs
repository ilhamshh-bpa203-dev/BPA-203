using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<GetProductVM> getProductVMs = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(p => new GetProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    ImageURL = p.ProductImages.Where(p => p.IsPrimary == true).FirstOrDefault().ImageURL
                })
                .ToListAsync();


            return View(getProductVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id is null || id < 1) return BadRequest();

            Product product = await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductImages)
                    .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            GetProductVM getProductVM = new GetProductVM
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.Category.Name,
                ImageURL = product.ProductImages.FirstOrDefault().ImageURL
            };

            return View(getProductVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Tag> tags = await _context.Tags.ToListAsync();
            List<Size> sizes = await _context.Sizes.ToListAsync();


            CreateProductVM createProductVM = new()
            {
                Categories = categories,
                Tags = tags,
                Sizes = sizes
            };

            return View(createProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            createProductVM.Categories = await _context.Categories.ToListAsync();
            createProductVM.Tags = await _context.Tags.ToListAsync();
            createProductVM.Sizes = await _context.Sizes.ToListAsync();

            if (createProductVM.Price < 0)
            {
                ModelState.AddModelError(nameof(createProductVM.Price), "Price cant be negative");
                return View(createProductVM);
            }

            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }


            if (!createProductVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(createProductVM.MainPhoto), "Image type incorrect");
                return View(createProductVM);
            }
            if (!createProductVM.MainPhoto.CheckFieSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(createProductVM.MainPhoto), "Image size must be less then 1 mb");
                return View(createProductVM);
            }

            if (!createProductVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(createProductVM.HoverPhoto), "Image type incorrect");
                return View(createProductVM);
            }
            if (!createProductVM.HoverPhoto.CheckFieSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(createProductVM.HoverPhoto), "Image size must be less then 1 mb");
                return View(createProductVM);
            }





            bool existsProduct = createProductVM.Categories.Any(c => c.Id == createProductVM.CategoryId);
            if (!existsProduct)
            {
                ModelState.AddModelError(nameof(CreateProductVM.CategoryId), "Category not exists");
                return View(createProductVM);
            }



            if (createProductVM.TagIds is not null)
            {
                bool existsTag = createProductVM.TagIds.Any(tId => !createProductVM.Tags.Exists(t => t.Id == tId));
                if (existsTag)
                {
                    ModelState.AddModelError(nameof(CreateProductVM.TagIds), "Tag not exists");
                    return View(createProductVM);
                }
            }

            if (createProductVM.SizeIds is not null)
            {
                bool existsSize = createProductVM.SizeIds.Any(sId => !createProductVM.Sizes.Exists(s=>s.Id == sId));
                if (existsSize)
                {
                    ModelState.AddModelError(nameof(CreateProductVM.SizeIds), "Size not found");
                    return View(createProductVM);
                }
            }

            ProductImage mainImage = new ProductImage()
            {
                ImageURL = await createProductVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true,

            };
            ProductImage hoverImage = new ProductImage()
            {
                ImageURL = await createProductVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false,

            };





            Product product = new()
            {
                Name = createProductVM.Name,
                Price = createProductVM.Price.Value,
                SKU = createProductVM.SKU,
                Description = createProductVM.Description,
                CategoryId = createProductVM.CategoryId.Value,
                ProductImages = new List<ProductImage>() { mainImage, hoverImage }
            };


            if (createProductVM.TagIds is not null)
            {
                product.ProductTags = createProductVM.TagIds.Select(tId => new ProductTag
                {
                    TagId = tId,
                }).ToList();
            }

            if (createProductVM.SizeIds is not null)
            {
                product.ProductSizes = createProductVM.SizeIds.Select(sId => new ProductSize
                {
                    SizeId = sId,
                }).ToList();
            }

            if (createProductVM.AdditionalPhoto is not null)
            {
                string text = string.Empty;
                foreach (IFormFile file in createProductVM.AdditionalPhoto)
                {

                    if (!file.CheckFileType("image/"))
                    {
                        text += $"   <p class=\"text-danger\">{file.FileName}</p>  type is incorrect";
                        continue;
                    }
                    if (!file.CheckFieSize(FileSize.MB, 1))
                    {
                        text += $"   <p class=\"text-danger\"> {file.FileName}</p> size is incorrect";
                        continue;
                    }


                    product.ProductImages.Add(
                        new ProductImage()
                        {
                            ImageURL = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                            IsPrimary = null,
                        }

                        );
                }
                TempData["FileWarning"] = text;

            }



            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Product product = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (product is null) return NotFound();

            UpdateProductVM updateProductVM = new UpdateProductVM()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                TagIds = product.ProductTags.Select(pt => pt.TagId).ToList(),
                ProductImages = product.ProductImages,
                Sizes = await _context.Sizes.ToListAsync(),
                SizeIds= product.ProductSizes.Select(ps => ps.SizeId).ToList(),

            };

            return View(updateProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateProductVM updateProductVM)
        {
            if (id is null || id < 1) return BadRequest();

            updateProductVM.Categories = await _context.Categories.ToListAsync();
            updateProductVM.Tags = await _context.Tags.ToListAsync();
            updateProductVM.Sizes=await _context.Sizes.ToListAsync();
           
            Product existsProduct = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p=>p.ProductSizes)
                .Include(p=>p.ProductImages)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existsProduct is null) return NotFound();

            updateProductVM.ProductImages = existsProduct.ProductImages;

            //if (!ModelState.IsValid)
            //{
            //    return View(updateProductVM);
            //}

           




            if (updateProductVM.TagIds is not null)
            {
                bool existsTag = updateProductVM.TagIds.Any(tId => !updateProductVM.Tags.Exists(t => t.Id == tId));
                if (existsTag)
                {
                    ModelState.AddModelError(nameof(UpdateProductVM.TagIds), "Tag not exists");
                    return View(updateProductVM);
                }
            }

            if (updateProductVM.SizeIds is not null)
            {
                bool existsTag = updateProductVM.SizeIds.Any(sId => !updateProductVM.Sizes.Exists(s => s.Id == sId));
                if (existsTag)
                {
                    ModelState.AddModelError(nameof(UpdateProductVM.SizeIds), "Size not exists");
                    return View(updateProductVM);
                }
            }

            if (updateProductVM.MainPhoto is not null)
            {
                if (!updateProductVM.MainPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(updateProductVM.MainPhoto), "Image type incorrect");
                    return View(updateProductVM);
                }
                if (!updateProductVM.MainPhoto.CheckFieSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(updateProductVM.MainPhoto), "Image size must be less then 1 mb");
                    return View(updateProductVM);
                }

            }
            if (updateProductVM.HoverPhoto is not null)
            {
                if (!updateProductVM.HoverPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(updateProductVM.HoverPhoto), "Image type incorrect");
                    return View(updateProductVM);
                }
                if (!updateProductVM.HoverPhoto.CheckFieSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(updateProductVM.HoverPhoto), "Image size must be less then 1 mb");
                    return View(updateProductVM);
                }

            }






            if (updateProductVM.CategoryId != existsProduct.CategoryId)
            {
                bool isExistsCategory = updateProductVM.Categories.Any(c => c.Id == updateProductVM.CategoryId);
                if (!isExistsCategory)
                {
                    ModelState.AddModelError(nameof(UpdateProductVM.CategoryId), "Category not exists");
                    return View(updateProductVM);
                }
            }



            if (updateProductVM.TagIds is null)
            {
                updateProductVM.TagIds = new();
            }
            else
            {
                updateProductVM.TagIds = updateProductVM.TagIds.Distinct().ToList();
            }

          
            //if (updateProductVM.SizeIds is null)
            //{
            //    updateProductVM.SizeIds = new();
            //}
            //else
            //{
            //    updateProductVM.SizeIds = updateProductVM.TagIds.Distinct().ToList();
            //}

        

            if (updateProductVM.TagIds is not null)
            {
                _context.ProductTags.RemoveRange(existsProduct.ProductTags
                    .Where(pTag => !updateProductVM.TagIds
                    .Exists(tId => tId == pTag.TagId))
                    .ToList());

                _context.ProductTags.AddRange(updateProductVM.TagIds
                    .Where(tId => !existsProduct.ProductTags
                    .Exists(pTag => pTag.TagId == tId))
                    .ToList()
                    .Select(tId => new ProductTag { TagId = tId, ProductId = existsProduct.Id }));
            }

            if (updateProductVM.SizeIds is not null)
            {
                _context.ProductSizes.RemoveRange(existsProduct.ProductSizes
                    .Where(pSize => !updateProductVM.SizeIds.Exists(sId=> sId == pSize.SizeId))
                    .ToList());
                _context.ProductSizes.AddRange(updateProductVM.SizeIds
                  .Where(sId => !existsProduct.ProductSizes
                  .Exists(pSize => pSize.SizeId == sId))
                  .ToList()
                  .Select(sId => new ProductSize { SizeId = sId, ProductId = existsProduct.Id }));
            }


            if (updateProductVM.MainPhoto is not null)
            {
                string fileName = await updateProductVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage mainImage = existsProduct.ProductImages.FirstOrDefault(p=>p.IsPrimary==true);


                mainImage.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                existsProduct.ProductImages.Remove(mainImage);

                existsProduct.ProductImages.Add(new ProductImage
                {
                    ImageURL = fileName,
                    IsPrimary = true,
                });
            }

            if (updateProductVM.HoverPhoto is not null)
            {
                string fileName = await updateProductVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage hoverImage = existsProduct.ProductImages.FirstOrDefault(p=>p.IsPrimary==false);

                hoverImage.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                existsProduct.ProductImages.Remove(hoverImage);

                existsProduct.ProductImages.Add(new ProductImage
                {
                    ImageURL = fileName,
                    IsPrimary = false,
                });

            }




            if( updateProductVM.ImageIds is null)
            {
                updateProductVM.ImageIds = new List<int>();
            }

            var deletedImage = existsProduct.ProductImages.Where(pi=>updateProductVM.ImageIds.Exists(imgIds=>imgIds==pi.Id) && pi.IsPrimary==null).ToList();

            deletedImage.ForEach(di=>di.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));

            _context.ProductImages.RemoveRange(deletedImage);

            if (updateProductVM.AdditionalPhoto is not null)
            {
                string text = string.Empty;
                foreach (IFormFile file in updateProductVM.AdditionalPhoto)
                {

                    if (!file.CheckFileType("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName}</p>  type is incorrect";
                        continue;
                    }
                    if (!file.CheckFieSize(FileSize.MB, 1))
                    {
                        text += $"<p class=\"text-danger\"> {file.FileName}</p> size is incorrect";
                        continue;
                    }


                    existsProduct.ProductImages.Add(
                        new ProductImage()
                        {
                            ImageURL = await file.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                            IsPrimary = null,
                        }

                        );
                }
                TempData["FileWarning"] = text;

            }


            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                // Debug üçün konsola çıxar
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }

                return View(updateProductVM);
            }


            existsProduct.Name = updateProductVM.Name;
            existsProduct.SKU = updateProductVM.SKU;
            existsProduct.CategoryId = updateProductVM.CategoryId.Value;
            existsProduct.Price = updateProductVM.Price.Value;
            existsProduct.Description = updateProductVM.Description;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();

            Product product = await _context.Products.Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            product.ProductImages.ForEach(pi => pi.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images") );

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
