using System;
using System.Collections.Generic;

namespace Task_1._3
{
    class Program
    {

        public interface IRegion
        {
            public string Brand { get; }
            public string Country { get; }
        }
        interface IRegionSettings
        {
            public string WebSite { get; }
        }

       public class Region : IRegion
        {
            string brand;
            string country;

            public Region( string brand , string country)
            {
                this.brand = brand;
                this.country = country;
            }
            string IRegion.Brand => brand;

            string IRegion.Country => country;

            public override bool Equals(object obj)
            {
                if (!(obj is Region)) return false;

                Region p = (Region)obj;
                return brand == p.brand & country == p.country;
            }

            public override int GetHashCode()
            {
                return brand.GetHashCode() ^ country.GetHashCode(); 
            }
            public string PrintInfo()
            {
                return $"[{brand},{country}]";
            }
        }
        public class RegionSettings : IRegionSettings
        {
            string webSite;

            public RegionSettings(string web)
            {
                webSite = web;
            }

            public string WebSite => webSite;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 1.3 , Work with Dictionary ");
            Console.WriteLine("Student of Pm Tech Academy Zicnhenko Bogdan");
            Console.WriteLine("Input information in dictionary , and continue work with it");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            int range;
            Console.WriteLine("Input range of your Dictionry");
            int.TryParse(Console.ReadLine(), out range);
            var regions = new Dictionary<Region, RegionSettings>(range);

            for (int i = 0; i < range; i++)
            {
                Console.Write($"Input pls Brand  = ");
                var brand = Console.ReadLine();
                if (brand == "exit") return;
                Console.Write($"Input pls Country  = ");
                var country = Console.ReadLine();
                Console.Write($"Input pls WebSite  = ");
                var webSite = Console.ReadLine();
                Region rg = new Region(brand, country);
                RegionSettings rs = new RegionSettings(webSite);
                if (regions.ContainsKey(rg))
                {
                    Console.WriteLine("The value with this brand and country is here");
                    i--;
                    continue;
                }
                regions.Add(rg, rs);
            }
            Console.WriteLine($"[Brand , Country]=[Web_Site]");
           foreach (KeyValuePair<Region, RegionSettings> keyValue in regions)
            {
                Console.WriteLine($"{keyValue.Key.PrintInfo()} = [{keyValue.Value.WebSite}]");
            }
             
            


        }
    }
}
