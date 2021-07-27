using Autofac;
using GildedRose.Business.Abstract;
using GildedRose.Business.DependencyResolvers.Autofac;
using GildedRose.Models.Entities;
using GildedRose.Models.Static;
using System;
using System.Collections.Generic;

namespace GildedRose.App
{
    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            //Managing Dependency Injection types
            IContainer container = BuildContainer();

            IList<Item> items = GetItemsCollection();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                for (var j = 0; j < items.Count; j++)
                {
                    Item item = items[j];

                    Console.WriteLine(item);

                    ICreateService createService = container.Resolve<ICreateService>();

                    IItemUpdateService updateService = createService.CreateUpdateService(item.Name);
                    updateService.UpdateItem(item);
                }
            }
        }

        /// <summary>
        /// Generates a collection of Item objects
        /// </summary>
        private static IList<Item> GetItemsCollection()
        {
            return new List<Item>{
                new Item {Name = StandardItemNames.DexterityVest, SellIn = 10, Quality = 20}, //Standard Item
                new Item {Name = NonStandardItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = StandardItemNames.Elixir, SellIn = 5, Quality = 7}, //Standard Item
                new Item {Name = NonStandardItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = NonStandardItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = NonStandardItemNames.BackstagePasses, SellIn = 15, Quality = 20},
                new Item {Name = NonStandardItemNames.BackstagePasses, SellIn = 10, Quality = 49},
                new Item {Name = NonStandardItemNames.BackstagePasses, SellIn = 5, Quality = 49},
                new Item {Name = NonStandardItemNames.Conjured, SellIn = 3, Quality = 6}
            };
        }

        /// <summary>
        /// Creating the Container for IoC
        /// </summary>
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacBusinessModule());

            return builder.Build();
        }
    }
}
