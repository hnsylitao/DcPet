﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DcPet.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DcPetEntities : DbContext
    {
        public DcPetEntities()
            : base("name=DcPetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<dc_area> dc_area { get; set; }
        public DbSet<dc_pet> dc_pet { get; set; }
        public DbSet<dc_pet_image> dc_pet_image { get; set; }
        public DbSet<dc_pettype> dc_pettype { get; set; }
        public DbSet<dc_user> dc_user { get; set; }
        public DbSet<dc_userdata> dc_userdata { get; set; }
    }
}
