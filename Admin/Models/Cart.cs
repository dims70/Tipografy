using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public static class Cart
    {
        private static List<Sketchs> Items { get; set; }
        static Cart()
        {
            Items = new List<Sketchs>();
        }
        public static void AddToCart(Sketchs sketchs)
        {
            Items.Add(sketchs);
        }
        public static void RemoveInCart(Sketchs sketchs)
        {
           var d = Items.Where(x=>x.idSketch==sketchs.idSketch).ToList().First();
            Items.Remove(d);
            
        }
        public static int CartCount()
        {
            return Items.Count();
        }
        public static List<Sketchs> getCart()
        {
            return Items;
        }
    }
}