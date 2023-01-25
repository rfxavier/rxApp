using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace rxApp.Models
{
    public class UserValidate
    {
        //private ApplicationUserManager userManager;

        //This method is used to check the user credentials
        public static ApplicationUser Login(string username, string password)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = Task.Run(() => userManager.FindAsync(username, password)).Result;

            var userWithCofres = userManager.Users.Include(u => u.GetLockCofres).FirstOrDefault(ul => ul.UserName == username);

            return userWithCofres;
        }
    }
}