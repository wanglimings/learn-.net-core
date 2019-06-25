using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MvcCookieAuthSample.Models;

namespace MvcCookieAuthSample.Data
{
    public class ApplicationDbContextSeed
    {
        private UserManager<ApplicationUser> _userManager;

        public async Task SeedAsyn(ApplicationDbContext context, IServiceProvider service)
        {
            if (!context.Users.Any())
            {
                _userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                var defaultUser = new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "wangliming@163.com",
                    NormalizedUserName = "admin"
                };
                var result =await _userManager.CreateAsync(defaultUser, "Password@123");
                if (!result.Succeeded)
                {
                    throw new Exception("初始默认用户失败!");
                }
            }
        }
    }
}
