using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;

namespace ProjectBookShoping.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles=Sd.Role_admin)]
    public class CategoryController : Controller
    { 
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            category = _unitOfWork.CategoryTypeRepository.Get(id.GetValueOrDefault());
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if(category.Id==0)
            {
                _unitOfWork.CategoryTypeRepository.Add(category);
            }
            else
            {
                _unitOfWork.CategoryTypeRepository.Update(category);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var CategoryList = _unitOfWork.CategoryTypeRepository.GetAll();
            return Json(new { data = CategoryList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.CategoryTypeRepository.Get(id);
            if (category == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.CategoryTypeRepository.Remove(category);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });
           
        }
        #endregion


    }

}
