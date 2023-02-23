using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;

namespace ProjectBookShoping.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = Sd.Role_admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
              _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null)
                return View(coverType);
            //-------------------using storedprocedure
            var param = new DynamicParameters();
            param.Add("@Id",id.GetValueOrDefault());
            coverType = _unitOfWork.sP_Call.OneRecord<CoverType>(Sd.proc_GetCoverType,param);

           //-------------------using simple method
           // coverType = _unitOfWork.coverTypeRepository.Get(id.GetValueOrDefault());
           //if(coverType == null)
           //    return NotFound();  
            return View(coverType); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType covertype)
        {
            if (covertype == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            var param = new DynamicParameters();
            param.Add("@Name", covertype.Name);
            if (covertype.Id==0)
            {
                //----------------using stored procedure
                
               
                _unitOfWork.sP_Call.Execute(Sd.proc_CreateCoverType,param);

                //-----------using simple method
               // _unitOfWork.coverTypeRepository.Add(covertype);

            }
            else
            {
                //---------using stored procedure
                param.Add("@Id", covertype.Id);
                _unitOfWork.sP_Call.Execute(Sd.proc_UpdateCoverType, param);

                //----------using simple method
               // _unitOfWork.coverTypeRepository.Update(covertype);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            //----------using store procedure
            var CoverTypeList = _unitOfWork.sP_Call.List<CoverType>(Sd.proc_GetCoverTypes);
            return Json(new { data = CoverTypeList });

            //----------using simple method
            //var coverType = _unitOfWork.coverTypeRepository.GetAll();
            //return Json(new {data=coverType});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var coverType = _unitOfWork.coverTypeRepository.Get(id);
            if(coverType==null)
                return Json(new {success=false,message="Something Went Wrong!!!"});
            _unitOfWork.coverTypeRepository.Remove(coverType);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data Deleted Successfully" });
        }

        #endregion
    }
}
