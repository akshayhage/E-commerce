using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using E_commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }
        public IActionResult Upsert(int? id)
        {
            
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().
            //    Select(u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    }
            //    );
           // ViewBag.CategoryList = CategoryList;
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u=>new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                }),
                Product = new Product()
            };
            if(id == null || id == 0)
            {   //create
                return View(productVM);
            }
            else
            {   //update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                });
                
                return View(productVM);
            }
           
            
            

        }

        //not neccessary bez of upsert function
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null | id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Product obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
