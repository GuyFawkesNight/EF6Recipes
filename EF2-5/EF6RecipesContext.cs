using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_5
{
    class EF6RecipesContext:DbContext
    {

        public EF6RecipesContext():base("name=EF6RecipesContext")
        {

        }
        public DbSet<PictureCategory> PictureCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PictureCategory>()
                .HasMany(cat => cat.SubCategories)
                .WithOptional(cat => cat.ParentCategory);
        }


    }
}
