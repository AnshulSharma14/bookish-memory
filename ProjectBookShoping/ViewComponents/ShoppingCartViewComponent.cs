using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectBookShoping.ViewComponents
{
    public class ShoppingCartViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                if (HttpContext.Session.GetInt32(Sd.SessionCart) != null)
                {
                    return View(HttpContext.Session.GetInt32(Sd.SessionCart));
                }
                else
                {
                    HttpContext.Session.SetInt32(Sd.SessionCart,
                        _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
                    return View(HttpContext.Session.GetInt32(Sd.SessionCart));
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}

