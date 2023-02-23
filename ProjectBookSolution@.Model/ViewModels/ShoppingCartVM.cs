using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.Model.ViewModels
{
	public class ShoppingCartVM
	{
        public OrderHeader Orderheader { get; set; }
        public IEnumerable<ShoppingCart> ListCart { get; set; }
	}
}
