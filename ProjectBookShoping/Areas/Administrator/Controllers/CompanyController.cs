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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> CategoryList { get; private set; }
       

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Company company = new();
    

            if (id == null||id==0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.FirstORDefault(u => u.Id == id);
                return View(company);
            }
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {
            if (obj.Id == 0)
            {
                _unitOfWork.Company.Add(obj);
            }
            else
            {
                _unitOfWork.Company.Update(obj);
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
            var CompanyList = _unitOfWork.Company.GetAll();
            return Json(new { data = CompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Company.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "something Went Wrong" });
            }
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });
        }
        #endregion


    }

}
 
