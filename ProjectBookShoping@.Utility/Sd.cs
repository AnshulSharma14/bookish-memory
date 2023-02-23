using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookShoping_.Utility
{
    public static class Sd
    {
        public const string proc_GetCoverTypes = "GetCoverTypes";
        public const string proc_GetCoverType = "GetCoverType";
        public const string proc_CreateCoverType = "CreateCoverType";
        public const string proc_UpdateCoverType = "UpdateCoverType";
        public const string proc_DeleteCoverType = "DeleteCoverType";

        public const string Role_User_Indi = "Individual";
        public const string Role_user_comp = "Company";
        public const string Role_admin = "Admin";
        public const string Role_Employee = "Employee";
       
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";
        public const string StatusPending = "pending";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
        public const string SessionCart = "SessionShoppingCart";
    }
}
