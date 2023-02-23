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
    public class _unitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;

        public _unitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryTypeRepository = new CategoryRepository(_context);
            coverTypeRepository = new CoverTypeRepository(_context);
            sP_Call = new SP_Call(_context);
            productTypeRepository=new ProductType(_context);
            Company=new CompanyRepository(_context);
            shopingCart = new ShoppingCartRepository(_context);
            ApplictionUser = new ApplicationRepository(_context);
            OrderDetailRepository = new OrderDetailRepository(_context);
            OrderHeaderRepository = new OrderHeaderRepository(_context);

        }

   

        public ICoverTypeRepository coverTypeRepository { get; private set; }

        public ICategory CategoryTypeRepository { get; private set; }

        public ISP_call sP_Call { get; private set; }

        public IProductTypeRepository productTypeRepository { get; private set; }
        public ICompany Company { get; private set; }

        public IApplictionUser ApplictionUser { get; private set; }

        public IShopingCart shopingCart { get; private set; }


        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public IOrderHeaderRepository OrderHeaderRepository { get; set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
