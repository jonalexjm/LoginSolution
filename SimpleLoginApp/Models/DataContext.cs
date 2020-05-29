using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginApp.Models
{
    public class DataContext : IdentityDbContext<UserEntity>

    {

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

       
    }
}
