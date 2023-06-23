using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using E_commerce.Models.ViewModels;
using E_commerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Runtime.Intrinsics.X86;


namespace E_commerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {   //create
                return View(new Company());
            }
            else
            {   //update
                Company companyObj= _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if(ModelState.IsValid)
            {
               
                if(companyObj.Id==0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }

                
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }else
            {
                return View(companyObj);
            }
            
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            Console.WriteLine(objCompanyList);

            return Json(new { data = objCompanyList });  
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if(companyToBeDeleted == null)
            {
                return Json(new {success=false,message="Error While deleting" });
            }
            
           
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully" });
        }
        #endregion

    }
}


