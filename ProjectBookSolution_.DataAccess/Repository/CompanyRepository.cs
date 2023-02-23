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
    public class CompanyRepository : Repository<Company>, ICompany
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Company company)
        {

            _context.Update(company);
        }
    }
}
