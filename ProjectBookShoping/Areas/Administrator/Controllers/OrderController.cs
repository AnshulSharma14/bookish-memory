using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using Stripe;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using ProjectBookSolution_.Model.ViewModels;
using System.Linq;

namespace ProjectBookShoping.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]
    public class OrderController : Controller
    {
       
       private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int orderId)
        {
            OrderVM orderVM = new OrderVM()
            {
                Orderheader = _unitOfWork.OrderHeaderRepository.FirstORDefault(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(u => u.Id == orderId, includeProperties: "product"),

            };
            return View(orderVM);
        }
        [HttpPost]
        [Authorize(Roles = Sd.Role_admin + "," + Sd.Role_Employee)]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOrderDetail()
        {
            var orderHEaderFromDb = _unitOfWork.OrderHeaderRepository.FirstORDefault(u => u.Id == OrderVM.Orderheader.Id, tracked: false);
            orderHEaderFromDb.Name = OrderVM.Orderheader.Name;
            orderHEaderFromDb.PhoneNumber = OrderVM.Orderheader.PhoneNumber;
            orderHEaderFromDb.StreetAddress = OrderVM.Orderheader.StreetAddress;
            orderHEaderFromDb.city = OrderVM.Orderheader.city;
            orderHEaderFromDb.State = OrderVM.Orderheader.State;
            orderHEaderFromDb.PostalCode = OrderVM.Orderheader.PostalCode;
            if (OrderVM.Orderheader.Carrier != null)
            {
                orderHEaderFromDb.Carrier = OrderVM.Orderheader.Carrier;
            }
            if (OrderVM.Orderheader.TrackingNumber != null)
            {
                orderHEaderFromDb.TrackingNumber = OrderVM.Orderheader.TrackingNumber;
            }
            _unitOfWork.OrderHeaderRepository.Update(orderHEaderFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Order Details Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = orderHEaderFromDb.Id });

        }
        [HttpPost]
        [Authorize(Roles = Sd.Role_admin + "," + Sd.Role_Employee)]
        [ValidateAntiForgeryToken]
        public IActionResult StartProcessing()
        {
            _unitOfWork.OrderHeaderRepository.UpdateStatus(OrderVM.Orderheader.Id, Sd.StatusInProcess);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status Updated Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.Orderheader.Id });
        }
        [HttpPost]
        [Authorize(Roles = Sd.Role_admin + "," + Sd.Role_Employee)]
        [ValidateAntiForgeryToken]
        public IActionResult ShipOrder()
        {
            var orderHeader = _unitOfWork.OrderHeaderRepository.FirstORDefault(u => u.Id == OrderVM.Orderheader.Id, tracked: false);
            orderHeader.TrackingNumber = OrderVM.Orderheader.TrackingNumber;
            orderHeader.Carrier = OrderVM.Orderheader.Carrier;
            orderHeader.OrderStatus = Sd.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;

            _unitOfWork.OrderHeaderRepository.Update(orderHeader);
            _unitOfWork.Save();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.Orderheader.Id });
        }

        [HttpPost]
        [Authorize(Roles = Sd.Role_admin + "," + Sd.Role_Employee)]
        [ValidateAntiForgeryToken]
        public IActionResult CancelOrder()
        {
            var orderHeader = _unitOfWork.OrderHeaderRepository.FirstORDefault(u => u.Id == OrderVM.Orderheader.Id, tracked: false);
            if (orderHeader.PaymentStatus == Sd.PaymentStatusApproved)
            {
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.paymentIntentId
                };
                var service = new RefundService();
                Refund refund = service.Create(options);

                _unitOfWork.OrderHeaderRepository.UpdateStatus(orderHeader.Id, Sd.StatusCancelled, Sd.StatusRefunded);
            }
            else
            {
                _unitOfWork.OrderHeaderRepository.UpdateStatus(orderHeader.Id, Sd.StatusCancelled, Sd.StatusCancelled);
            }
            _unitOfWork.Save();

            TempData["Success"] = "Order Cancelled Successfully.";
            return RedirectToAction("Details", "Order", new { orderId = OrderVM.Orderheader.Id });
        }



        #region APIs
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> orderheaders;
            if (User.IsInRole(Sd.Role_admin) || User.IsInRole(Sd.Role_Employee))
            {
                orderheaders = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser");

            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                orderheaders = _unitOfWork.OrderHeaderRepository.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "ApplicationUser");
            }
            switch (status)
            {
                case "approved":
                    orderheaders = orderheaders.Where(u => u.OrderStatus == Sd.StatusApproved);
                    break;
                case "inprocess":
                    orderheaders = orderheaders.Where(u => u.OrderStatus == Sd.StatusInProcess);
                    break;
                case "completed":
                    orderheaders = orderheaders.Where(u => u.OrderStatus == Sd.StatusShipped);
                    break;
                default:
                    break;
            }
            return Json(new { data = orderheaders });
        }
        #endregion
    }
}
