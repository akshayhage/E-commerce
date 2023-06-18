using E_commerce.DataAccess.Data;
using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceWeb.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Add(obj);
                categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null|id==0)
            {
                return NotFound();
            }
            Category categoryFromDb = categoryRepo.Get(u=>u.Id==id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Update(obj);
                categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = categoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = categoryRepo.Get(u => u.Id == id);
            if (obj==null)
            {
                return NotFound();
            }
            categoryRepo.Remove(obj);
            categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
