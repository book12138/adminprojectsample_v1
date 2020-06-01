using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.EF
{
    /// <summary>
    /// EF 上下文
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        { }

        public DbSet<BM_Menu> BM_Menu { get; set; }
        public DbSet<BM_User> BM_User { get; set; }
        public DbSet<BM_Role> BM_Role { get; set; }
        public DbSet<BM_RoleMenu> BM_RoleMenu { get; set; }
        public DbSet<BM_UserRole> BM_UserRole { get; set; }
    }
}
