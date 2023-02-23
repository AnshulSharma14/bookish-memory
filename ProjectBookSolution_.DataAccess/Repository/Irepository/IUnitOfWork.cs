using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository.Irepository
{
    public interface IUnitOfWork
    {
        ICategory CategoryTypeRepository { get; }
        ICoverTypeRepository coverTypeRepository { get; }
        ISP_call sP_Call { get; }
        IProductTypeRepository productTypeRepository { get; }

        ICompany Company{ get;}
        IApplictionUser ApplictionUser { get; }
        IShopingCart shopingCart { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderHeaderRepository OrderHeaderRepository { get; }
        void Save();
    }
}
