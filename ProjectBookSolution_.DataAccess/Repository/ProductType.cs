using Microsoft.Build.Framework;
using ProjectBookShoping.Data;
using ProjectBookSolution_.DataAccess.Repository.Irepository;
using ProjectBookSolution_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository
{
    public class ProductType : Repository<Product>, IProductTypeRepository
    {
        private ApplicationDbContext _context;
        public ProductType(ApplicationDbContext context): base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var objFromdb=_context.Products.FirstOrDefault(s=>s.Id==product.Id);
            if(objFromdb!=null)
            {
               
                objFromdb.Title = product.Title;
                objFromdb.ISBN = product.ISBN;
                objFromdb.Price = product.Price;
                objFromdb.Price50 = product.Price50;
                objFromdb.Author = product.Author;
                objFromdb.Description = product.Description;
                objFromdb.CategoryId= product.CategoryId;
                objFromdb.CoverTypeId= product.CoverTypeId;
                objFromdb.ListPrice = product.ListPrice;
                objFromdb.Price100= product.Price100;
                if (objFromdb.ImageUrl != null)
                {
                    objFromdb.ImageUrl = product.ImageUrl;
                }

            }
            
           
        }
    }
}
