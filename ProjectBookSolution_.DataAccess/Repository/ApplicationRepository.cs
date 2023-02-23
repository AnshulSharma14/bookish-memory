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
    public class ApplicationRepository : Repository<ApplicationUser>, IApplictionUser
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public void Update(ApplicationUser applicationUser)
        {
            _context.Update(applicationUser);
        }
    }
}
