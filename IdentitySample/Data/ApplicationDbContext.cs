﻿using System;
using System.Collections.Generic;
using System.Text;
using IdentitySample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ErrorViewModel> ErrorViewModel {get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
