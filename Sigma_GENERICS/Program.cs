using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_GENERICS
{
    class Program
    {
        static void Main(string[] args)
        {
            Animals<Pet> pets = new Animals<Pet>();
            pets.AddItem(new Dog() { Name = "Robo", Breed = "Kolli" });
            pets.AddItem(new Dog() { Name = "Tobo", Breed = "Setter" });
            pets.AddItem(new Dog() { Name = "Hobo", Breed = "Shephard" });
            pets.AddItem(new Cat() { Name = "Tom", Breed = "Kat1" });
            pets.AddItem(new Cat() { Name = "Mom", Breed = "Kat2" });

            Console.WriteLine("List of all pets: dogs and cats:");
            pets.ProcessAllAnimals();
            Console.WriteLine();


            IList<Dog> dogsss = new List<Dog>()
            {
                     new Dog() { Name = "Rembo", Breed ="Kolli"},
                     new Dog() { Name = "Monet", Breed = "Kolli" },
            };

            pets.AddItem(dogsss[0]);

            Console.WriteLine("Introduce a dog:");
            dogsss[0].Introduce();
            Console.WriteLine();


            Console.WriteLine(" Update List of all pets: dogs and cats:");
         
            pets.ProcessAllAnimals();
            Console.WriteLine();

            Console.WriteLine("Introduce all dogs:");

            Animals<Dog> dogs = new Animals<Dog>();
            dogs.AddItem(new Dog() { Name = "RoboT" });
            dogs.AddItem(new Dog() { Name = "ToboT" });
            dogs.AddItem(new Dog() { Name = "HoboT" });

            dogs.ProcessAllAnimals();
            Console.WriteLine();

        }

        class Pet
        {
            public string Name { get; set; }
            public string Breed { get; set; }

            public void Introduce()
            {
                Console.WriteLine("My name is {0}. I am {1} ", this.Name, this.Breed, this.GetType().Name.ToString());
                Console.ReadKey();
            }

        }

        class Dog : Pet
        {



        }

        class Cat : Pet
        {

        }

        class Animals<T> where T : class
        {
            private List<T> items;


            public Animals()
            {
                this.items = new List<T>();
            }

            public void AddItem(T newItem)
            {
                items.Add(newItem);
            }

            public void DeleteItem(T itemToRemove)
            {
                items.Remove(itemToRemove);
            }

            public void ProcessAllAnimals()
            {
                foreach (T item in items)
                {
                    var PropertyInfos = item.GetType().GetProperties();

                    foreach (System.Reflection.PropertyInfo pInfo in PropertyInfos)
                    {
                        string propertyName = pInfo.Name; //gets the name of the property


                        Console.Write(propertyName);
                        Console.WriteLine(pInfo.GetValue(item, null));


                    }
                    Console.WriteLine(" I am {0} ", item.GetType().Name.ToString());

                    //  this.GetType().GetProperty(propertyName).GetValue(this, null)


                }
                Console.ReadLine();
            }
        }
    }


}
