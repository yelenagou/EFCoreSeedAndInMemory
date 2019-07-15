using System;
using System.Linq;

namespace DemoStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new CoffeeShopContext())
            {
                var locations=context.Locations.ToList();

            }
        }
    }
}
