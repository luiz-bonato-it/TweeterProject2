using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TwitterProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Hashtag> Hashtag { get; set; }
        public DbSet<PostHashtag> PostHashtag { get; set; }
        public DbSet<VinculoUsuario> VinculoUsuario { get; set; }

        //public System.Data.Entity.DbSet<TwitterProject.Models.ApplicationUser> IdentityUsers { get; set; }

    }
}