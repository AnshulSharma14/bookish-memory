using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.Model.ViewModels
{
    public class OrderVM
    {

        public OrderHeader Orderheader { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
