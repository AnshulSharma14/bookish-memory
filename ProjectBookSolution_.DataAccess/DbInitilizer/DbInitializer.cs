
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectBookShoping_.Utility;
using ProjectBookSolution_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookShoping.Data.DbInitilizer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(Sd.Role_admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(Sd.Role_admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Sd.Role_Employee)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Sd.Role_User_Indi)).GetAwaiter().GetResult();
                   _roleManager.CreateAsync(new IdentityRole(Sd.Role_user_comp)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "anshul1906031014@gmail.com",
                    Email = "anshul1906031014@gmail.com",
                    Name = "Anshul Sharma",
                    PhoneNumber = "7876130160",
                    StreetAddress = "Hamirpur",
                    State = "Himachal Pradesh",
                    PostalCode = "177038",
                    City = "Hamirput"
                }, "Anshul@2023").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "anshul1906031014@gmail.com");

                _userManager.AddToRoleAsync(user, Sd.Role_admin).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
