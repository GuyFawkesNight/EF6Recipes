﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new EF6RecipesContext())
            {
                var person = new Person { FirstName = "Robert", MiddleName = "Allen", LastName = "Doe", PhoneNumber = "867-5309" };
                context.People.Add(person);

                person = new Person { FirstName = "John", MiddleName = "K.", LastName = "Smith", PhoneNumber = "824-3031" };
                context.People.Add(person);

                person = new Person { FirstName = "Billy", MiddleName = "Albert", LastName = "Minor", PhoneNumber = "907-2212" };
                context.People.Add(person);

                person = new Person { FirstName = "Kathy", MiddleName = "Anne", LastName = "Ryan", PhoneNumber = "722-0038" };
                context.People.Add(person);

                context.SaveChanges();
            }

            using(var context = new EF6RecipesContext())
            {
                foreach(var person in context.People)
                {
                    Console.WriteLine("{0} {1} {2},Phone:{3}",person.FirstName,person.MiddleName,person.LastName,person.PhoneNumber);
                }
            }

            Console.ReadKey();
        }
    }
}
