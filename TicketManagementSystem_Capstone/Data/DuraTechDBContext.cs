﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketManagementSystem_Capstone.Database
{
    public class DuraTechDbContext : DbContext
    {

        public DuraTechDbContext(DbContextOptions<DuraTechDbContext> options) 
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
