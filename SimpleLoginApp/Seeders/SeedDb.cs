using SimpleLoginApp.Helpers;
using SimpleLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginApp.Seeders
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(
           DataContext context,
           IUserHelper userHelper
           )
        {
            _context = context;
            _userHelper = userHelper;            
           
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", 
                                 "john alexander", 
                                 "Jimenez", 
                                 "jonalexjm@hotmail.com", 
                                 "312 803 56 24", 
                                 "Popayan", 
                                 UserType.Admin);
            await CheckUserAsync("303",
                                 "Andrea",
                                 "lopez",
                                 "andrea@hotmail.com",
                                 "31289344334",
                                 "Cali",
                                 UserType.User);


        }

        private async Task<UserEntity> CheckUserAsync(
                                                        string document,
                                                        string firstName,
                                                        string lastName,
                                                        string email,
                                                        string phone,
                                                        string address,
                                                        UserType userType)

        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }
    }
}
