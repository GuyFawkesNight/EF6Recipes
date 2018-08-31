using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EF6RecipesContext())
            {
                var louvre = new PictureCategory { Name = "Louvre" };
                var child = new PictureCategory { Name = "Egyptian Antiquites" };
                louvre.SubCategories.Add(child);

                child = new PictureCategory { Name = "Sculptures" };
                louvre.SubCategories.Add(child);

                var paris = new PictureCategory { Name = "Paris" };
                paris.SubCategories.Add(louvre);

                var vacation = new PictureCategory { Name = "Summer Vacation" };
                vacation.SubCategories.Add(paris);

                //context.PictureCategories.Add(paris); 原书中代码存在问题
                context.PictureCategories.Add(vacation);
                context.SaveChanges();
            }

            using (var context = new EF6RecipesContext())
            {
                var roots = context.PictureCategories.Where(c => c.ParentCategory == null);
                //此时对象不是List<>所以不能直接使用ForEach（）方法
                roots.ToList().ForEach(root => Print(root, 0));
            }

            Console.ReadKey();
        }

        static void Print(PictureCategory cat,int level)
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("{0}{1}",sb.Append(' ',level).ToString(),cat.Name);
            cat.SubCategories.ForEach(child => Print(child, level + 1));
        }
    }
}
