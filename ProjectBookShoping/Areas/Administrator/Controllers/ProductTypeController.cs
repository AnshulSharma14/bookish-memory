using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using ProjectBookSolution_.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.WebPages.Html;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace ProjectBookShoping.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = Sd.Role_admin)]
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IEnumerable<SelectListItem> CategoryList { get; private set; }
        public IEnumerable<SelectListItem> CoverTypeList { get; private set; }


        public ProductTypeController(IUnitOfWork unitOfWork,IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product  = new Product(),
                CategoryList =_unitOfWork.CategoryTypeRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList =_unitOfWork.coverTypeRepository.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),

            };

            if (id == null||id==0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.productTypeRepository.FirstORDefault(u => u.Id == id);
                return View(productVM);
            }
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\ProductImg");
                    var extension = Path.GetExtension(file.FileName);
                    if(obj.Product.ImageUrl!=null)
                    {
                        var oldImagePath=Path.Combine(wwwRootPath,obj.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var FileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(FileStreams);
                    }
                    obj.Product.ImageUrl = @"\images\ProductImg\" + filename + extension;
                }
            
            if (obj.Product.Id == 0)
            {
                _unitOfWork.productTypeRepository.Add(obj.Product);
            }
            else
            {
                _unitOfWork.productTypeRepository.Update(obj.Product);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        return View(obj);
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return Json(new { data = productList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.productTypeRepository.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "something Went Wrong" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.productTypeRepository.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });
        }
        #endregion


    }

}
 
