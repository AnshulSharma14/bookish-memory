using ProjectBookSolution_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository.Irepository
{
   public interface ICategory:Irepository<Category>
    {
        void Update(Category category);
    }
}
