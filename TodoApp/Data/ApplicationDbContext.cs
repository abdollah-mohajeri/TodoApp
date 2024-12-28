
using global::TodoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // کانستراکتور کلاس DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // اینجا مدل‌های داده‌ای خود را تعریف می‌کنید
        public DbSet<Todo> Todos { get; set; }  // مدل Todo به جدول Todos نگاشت می‌شود
    }
}
