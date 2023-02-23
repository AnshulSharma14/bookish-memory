using ProjectBookShoping.Data;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShopingCart
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int DecrementCount(ShoppingCart shoppingcart, int count)
        {
            shoppingcart.Count -= count;
            return shoppingcart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingcart, int count)
        {
            shoppingcart.Count += count;
            return shoppingcart.Count;
        }
    }
}
