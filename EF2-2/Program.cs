using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new EFRecipesEntities())
            {
                var poet = new Poet { FirstName = "John", LastName = "Milton" };
                var poem = new Poem { Title = "Paradise Lost" };
                var meter = new Meter { MeterName = "Iambic Pentameter" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                poem = new Poem { Title = "Paradise Regained" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                poet = new Poet { FirstName = "Lewis", LastName = "Carroll" };
                poem = new Poem { Title = "The Hunting of Shark" };
                meter = new Meter { MeterName = "Anapestic Tetrameter" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                poet = new Poet { FirstName = "Lord", LastName = "Byron" };
                poem = new Poem { Title = "Don Juan" };
                poem.Meter = meter;
                poem.Poet = poet;
                context.Poems.Add(poem);

                context.SaveChanges();

            }

            using (var context = new EFRecipesEntities())
            {
                var poets = context.Poets;
                foreach (var poet in poets)
                {
                    Console.WriteLine("{0} {1}", poet.FirstName, poet.LastName);
                    foreach (var poem in poet.Poems)
                    {
                        Console.WriteLine("\t{0} ({1})",poem.Title,poem.Meter.MeterName);
                    }
                }
            }

            using (var context = new EFRecipesEntities())
            {
                var items = context.vwLibraries;
                foreach (var item in items)
                {
                    Console.WriteLine("{0} {1}",item.FirstName,item.LastName);
                    Console.WriteLine("\t{0} ({1})",item.Title,item.MeterName);
                }
            }

            Console.ReadKey();
        }
    }
}
