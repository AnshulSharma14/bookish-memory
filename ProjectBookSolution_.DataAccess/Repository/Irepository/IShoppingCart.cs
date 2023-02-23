using ProjectBookSolution_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository.Irepository
{
   public interface IShopingCart:Irepository<ShoppingCart>
    {
      int IncrementCount(ShoppingCart shoppingcart, int count);
        int DecrementCount(ShoppingCart shoppingcart, int count);
    }
}
