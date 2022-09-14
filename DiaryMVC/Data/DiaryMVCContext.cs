using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiaryMVC.Models;

namespace DiaryMVC.Data
{   
    public class DiaryMVCContext : DbContext
    {
        public DiaryMVCContext (DbContextOptions<DiaryMVCContext> options)
            : base(options)
        {
        }

        public DbSet<DiaryMVC.Models.TopicClass> TopicClass { get; set; }
    }
}
