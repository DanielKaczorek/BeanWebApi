using BeanWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi.Data
{
    public class BeanContext : DbContext
    {
        public BeanContext(DbContextOptions<BeanContext> options): base(options)
        {
        }

        public DbSet<Bean> Bean { get; set; }
        public DbSet<BeanOfTheDay> BeanOfTheDay { get; set; }
    }
}
