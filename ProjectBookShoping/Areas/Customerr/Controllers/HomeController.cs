using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using ProjectBookShoping.Models;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using ProjectBookSolution_.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectBookShoping.Areas.Customerr.Controllers
{
    [Area("Customerr")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
           
        }
        [HttpGet]
        public async Task<IActionResult> IndexSearch(string productsearch)
        {

            if (string.IsNullOrEmpty(productsearch))
            {
                IEnumerable<Product> products = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
                return View(products);

            }
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll
                  (includeProperties: "Category").Where(x => x.Author.Contains(productsearch) || x.Category.Name.Contains(productsearch) ||
                  x.Title.Contains(productsearch));
            return View(productList);
        }
        public IActionResult ProductAll()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Novels()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Manga()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Adventure()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Biography()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Artist()
        {
            IEnumerable<Product> productList = _unitOfWork.productTypeRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }
       
        public IActionResult Details(int ProductId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                ProductId = ProductId,
                product = _unitOfWork.productTypeRepository.FirstORDefault(u => u.Id ==ProductId , includeProperties: "Category")
            };

            return View(cartObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            ShoppingCart cartFromDb = _unitOfWork.shopingCart.FirstORDefault(
              u => u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);
            if (cartFromDb == null)
            {

                _unitOfWork.shopingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(Sd.SessionCart,
                  _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
            }
            else
            {
                _unitOfWork.shopingCart.IncrementCount(cartFromDb, shoppingCart.Count);
                _unitOfWork.Save();
            }


            return RedirectToAction(nameof(Index));
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
