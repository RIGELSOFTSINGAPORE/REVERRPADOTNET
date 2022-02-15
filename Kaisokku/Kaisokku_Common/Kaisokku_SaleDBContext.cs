using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class Kaisokku_SaleDBContext : DbContext
    {
        public Kaisokku_SaleDBContext() : base("name = Kaisokku_SaleDBContext")
        {

        }
        //public DbSet<tbl_MenuMaster> tblmenumaster { get; set; }
        //public DbSet<Employee> Employeesss { get; set; }
        //public DbSet<dep> deps { get; set; }
        //public virtual DbSet<tbl_MenuMaster> tbl_MenuMaster { get; set; }
        //public virtual DbSet<tbl_RoleMaster> tbl_RoleMaster { get; set; }
        //public virtual DbSet<tbl_RoleMenuMapping> tbl_RoleMenuMapping { get; set; }
        //public virtual DbSet<tbl_UserMaster> tbl_UserMaster { get; set; }
        //public Menu menus { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<tbl_MenuMaster>()
        //        .Property(e => e.MenuName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tbl_MenuMaster>()
        //        .Property(e => e.ControllerName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tbl_MenuMaster>()
        //        .Property(e => e.ActionMethod)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tbl_RoleMaster>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tbl_UserMaster>()
        //        .Property(e => e.UserId)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<tbl_UserMaster>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);
        //}
    }
}
