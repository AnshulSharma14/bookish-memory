using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using ProjectBookSolution_.Model.ViewModels;
using Stripe.Checkout;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectBookShoping.Areas.Customerr.Controllers
{
    [Area("Customerr")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == claim.Value,
               includeProperties: "product"),
                Orderheader = new()
            };
            foreach (var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.product.Price,
                    cart.product.Price50);
                ShoppingCartVM.Orderheader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }
        public IActionResult Summary()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == claim.Value,
               includeProperties: "product"),
                Orderheader = new()
            };



            ShoppingCartVM.Orderheader.ApplicationUser = _unitOfWork.ApplictionUser.FirstORDefault(
                u => u.Id == claim.Value);
            ShoppingCartVM.Orderheader.Name = ShoppingCartVM.Orderheader.ApplicationUser.Name;
            ShoppingCartVM.Orderheader.PhoneNumber = ShoppingCartVM.Orderheader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.Orderheader.StreetAddress = ShoppingCartVM.Orderheader.ApplicationUser.StreetAddress;
            ShoppingCartVM.Orderheader.city = ShoppingCartVM.Orderheader.ApplicationUser.City;
            ShoppingCartVM.Orderheader.State = ShoppingCartVM.Orderheader.ApplicationUser.State;
            ShoppingCartVM.Orderheader.PostalCode = ShoppingCartVM.Orderheader.ApplicationUser.PostalCode;
            foreach (var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.product.Price,
                    cart.product.Price50);
                ShoppingCartVM.Orderheader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);

        }
        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public IActionResult SummaryPost(ShoppingCartVM ShoppingCartVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM.ListCart = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "product");
            ShoppingCartVM.Orderheader.PaymentStatus = Sd.PaymentStatusPending;
            ShoppingCartVM.Orderheader.OrderStatus = Sd.StatusPending;
            ShoppingCartVM.Orderheader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.Orderheader.ApplicationUserId = claim.Value;


            foreach (var cart in ShoppingCartVM.ListCart)
            {
                cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.product.Price,
                    cart.product.Price50);
                ShoppingCartVM.Orderheader.OrderTotal += (cart.Price * cart.Count);
            }
            _unitOfWork.OrderHeaderRepository.Add(ShoppingCartVM.Orderheader);
            _unitOfWork.Save();
            foreach (var cart in ShoppingCartVM.ListCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = cart.ProductId,
                    OrderId = ShoppingCartVM.Orderheader.Id,
                    Price = cart.Price,
                    Count = cart.Count,
                };
                _unitOfWork.OrderDetailRepository.Add(orderDetail);
                _unitOfWork.Save();

            }

            //stripe settings
            var domain = "https://projectbookshoping20230223180851.azurewebsites.net/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },

                LineItems = new List<SessionLineItemOptions>()
               ,
                Mode = "payment",
                SuccessUrl = domain + $"customerr/cart/OrderConfirmation?id={ShoppingCartVM.Orderheader.Id}",
                CancelUrl = domain + "customer/cart/index",
            };
            foreach (var item in ShoppingCartVM.ListCart)
            {
                var sessionLineItem = new SessionLineItemOptions

                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)item.Price * 100,
                        Currency = "INR",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.product.Title
                        },


                    },
                    Quantity = item.Count,
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            //ShoppingCartVM.Orderheader.SessionId = session.Id;
            //ShoppingCartVM.Orderheader.paymentIntentId=session.PaymentIntentId;
            _unitOfWork.OrderHeaderRepository.UpdateStripePaymentID(ShoppingCartVM.Orderheader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);


            //_unitOfWork.ShoppingCart.RemoveRange(ShoppingCartVM.ListCart);
            //_unitOfWork.Save();

            //return RedirectToAction("Index","Home");
        }
        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader Orderheader = _unitOfWork.OrderHeaderRepository.FirstORDefault(u => u.Id == id, includeProperties: "ApplicationUser");
            var service = new SessionService();
            Session session = service.Get(Orderheader.SessionId);
            //check the stripe status
            if (session.PaymentStatus.ToLower() == "paid")
            {
                _unitOfWork.OrderHeaderRepository.UpdateStripePaymentID(id, Orderheader.SessionId, session.PaymentIntentId);
                _unitOfWork.OrderHeaderRepository.UpdateStatus(id, Sd.StatusApproved, Sd.PaymentStatusApproved);
                _unitOfWork.Save();
            }
            _emailSender.SendEmailAsync(Orderheader.ApplicationUser.Email, "new Order -  Book World", "<p> New order has been Created Thank for shopping with us");
            List<ShoppingCart> shoppingCarts = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == Orderheader.ApplicationUserId).ToList();
            HttpContext.Session.Clear();
            _unitOfWork.shopingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();

            return View(id);

        }
        public IActionResult plus(int cartId)
        {
            var cart = _unitOfWork.shopingCart.FirstORDefault(u => u.Id == cartId);
            _unitOfWork.shopingCart.IncrementCount(cart, 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Minus(int cartId)
        {
            var cart = _unitOfWork.shopingCart.FirstORDefault(u => u.Id == cartId);
            if (cart.Count <= 1)
            {
                _unitOfWork.shopingCart.Remove(cart);
                var count = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count - 1;
                HttpContext.Session.SetInt32(Sd.SessionCart, count);
            }
            else
            {
                _unitOfWork.shopingCart.DecrementCount(cart, 1);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.shopingCart.FirstORDefault(u => u.Id == cartId);
            _unitOfWork.shopingCart.Remove(cart);
            _unitOfWork.Save();
            var count = _unitOfWork.shopingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(Sd.SessionCart, count);
            return RedirectToAction(nameof(Index));


        }

        private double GetPriceBasedOnQuantity(double quantity, double price, double price50)
        {
            if (quantity <= 50)
            {
                return price;
            }
            else
                return price50;

        }
    }
}

