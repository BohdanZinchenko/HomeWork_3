using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Task_2
{
    public static class CheckNull 
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
        
    }
  

    public class WorkSpace
    {
        List<Product> listProd;
        List<Tag> listTag;
        List<Leftovers> listLeft;
        private int ChoseMenu;
        public WorkSpace(List<Product> listProd, List<Tag> listTag, List<Leftovers> listLeft)
        {
            this.listProd = listProd;
            this.listTag = listTag;
            this.listLeft = listLeft;
        }
        public void ShowMenu()
        {
            Console.WriteLine("1. Exit");
            Console.WriteLine("2. Product");
            Console.WriteLine("3. Leftovers");

            while (!int.TryParse(Console.ReadLine(), out ChoseMenu) && ChoseMenu < 0 || ChoseMenu > 4)
            {
                Console.WriteLine("Error input , chose something from 1 to 3 ");
            }
            switch (ChoseMenu)
            {
                case 1:
                    return;
                case 2:
                    ProductMenu();
                    break;
                case 3:
                    LeftMenu();
                    break;
                default:
                    Console.WriteLine("You chouse wrong command ,chose something from 1 to 3");
                    ShowMenu();
                    break;
            }
        }
        public void ProductMenu()
        {
            Console.WriteLine("1. Back");
            Console.WriteLine("2. Find Product");
            Console.WriteLine("3. Sorted Product List by up price");
            Console.WriteLine("4. Sorted Product List by less price");
            while (!int.TryParse(Console.ReadLine(), out ChoseMenu) && ChoseMenu < 0 || ChoseMenu > 5)
            {
                Console.WriteLine("Error input , chose something from 1 to 4");
            }
            switch (ChoseMenu)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    FindProduct();
                    ProductMenu();
                    break;
                case 3:
                    SortProdUp();
                    ProductMenu();
                    break;
                case 4:
                    SortProdDown();
                    ProductMenu();
                    break;
                default:
                    Console.WriteLine("You chouse wrong command ,chose something from 1 to 4");
                    ProductMenu();
                    break;
            }
        }
        public void LeftMenu()
        {
            Console.WriteLine("1. Back");
            Console.WriteLine("2. Show product that are not in stock");
            Console.WriteLine("3. Sorted Product List by up price");
            Console.WriteLine("4. Sorted Product List by less price");
            Console.WriteLine("5. Find elem by id ");

            while (!int.TryParse(Console.ReadLine(), out ChoseMenu) && ChoseMenu < 0 || ChoseMenu > 6)
            {
                Console.WriteLine("Error input , chose something from 1 to 5");
            }
            switch (ChoseMenu)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    MissedProduct();
                    LeftMenu();
                    break;
                case 3:
                    LeftoversSortByup();
                    LeftMenu();
                    break;
                case 4:
                    LeftoversSortByDown();
                    LeftMenu();
                    break;
                case 5:
                    FindId();
                    LeftMenu();
                    break;
                default:
                    Console.WriteLine("You chouse wrong command ,chose something from 1 to 5");
                    LeftMenu();
                    break;


            }
        }

        public void SortProdUp()
        {
            var sortedLP = listProd.GroupJoin(listTag, x => x.id, y => y.product_id, (x, y) => new { id = x.id, brand = x.brand, model = x.model, price = x.price, Tags = y.Select(p => p.tag) }).OrderBy(x => x.price).Distinct();

            foreach (var item in sortedLP)
            {
                Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} [");
                foreach (var tag in item.Tags)
                {
                    Console.Write($" {tag} ");
                }
                Console.WriteLine("]");
            }
        }
        public void SortProdDown()
        {
            var sortedLP = listProd.GroupJoin(listTag, x => x.id, y => y.product_id, (x, y) => new { id = x.id, brand = x.brand, model = x.model, price = x.price, Tags = y.Select(p => p.tag) }).OrderByDescending(x => x.price).Distinct();

            foreach (var item in sortedLP)
            {
                Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} [");
                foreach (var tag in item.Tags)
                {
                    Console.Write($" {tag} ");
                }
                Console.WriteLine("]");
            }
        }
        


        public void FindProduct()
        {
            
            string findElem;
            bool finded = false;
            Console.Write("Pls input what you want tot find ");
            findElem = Console.ReadLine();
            var elem = listProd.GroupJoin(listTag, x => x.id, y => y.product_id, (x, y) => new { id = x.id, brand = x.brand, model = x.model, price = x.price, Tags = y.Select(p => p.tag) }).Where(x => x.id == findElem);
            if (CheckNull.IsNullOrEmpty(elem))
            {
                
            }
            else
            {
                finded = true;
                foreach (var item in elem)
                {
                    Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} [");
                    foreach (var tag in item.Tags)
                    {
                        Console.Write($" {tag} ");
                    }
                    Console.WriteLine("]");
                }
            }
            elem = listProd.GroupJoin(listTag, x => x.id, y => y.product_id, (x, y) => new { id = x.id, brand = x.brand, model = x.model, price = x.price, Tags = y.Select(p => p.tag) }).Where(x => x.brand == findElem || x.model == findElem);
            if (CheckNull.IsNullOrEmpty(elem))
            {
                
            }
            else
            {
                finded = true;
                foreach (var item in elem)
                {
                    Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} [");
                    foreach (var tag in item.Tags)
                    {
                        Console.Write($" {tag} ");
                    }
                    Console.WriteLine("]");
                }
            }
            var CheckTag = listTag.Where(x => x.tag == findElem).Select(x => x);
            if (CheckNull.IsNullOrEmpty(CheckTag))
            {

            }
            else
            {
                elem = listProd.GroupJoin(listTag, x => x.id, y => y.product_id, (x, y) => new { id = x.id, brand = x.brand, model = x.model, price = x.price, Tags = y.Select(p => p.tag) });
                elem = elem.Where(x => x.Tags.Contains(findElem));
                finded = true;
                foreach (var item in elem)
                {
                    Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} [");
                    foreach (var tag in item.Tags)
                    {
                        Console.Write($" {tag} ");
                    }
                    Console.WriteLine("]");
                }
            }
            
            if(finded == false)
            {
                Console.WriteLine("Element not founded");
            }
            
            

        }
        
        public void MissedProduct()
        {
            List<Product> lp = new List<Product>();
            
            var elem = listLeft.Select(x => x.product_id);
            foreach(var item in elem)
            {
                var elem2 = listProd.Select(x => x).Where(x => x.id == item);
                lp.Add(elem2.First());  
            }
            var msProduct = listProd.Except(lp);
            lp = msProduct.ToList();
            lp.OrderBy(x => x.id);
            foreach (var item in msProduct)
            {
                Console.Write($"#{item.id} {item.brand} - {item.model} - ${item.price} ");
            }
        }
        public void LeftoversSortByup()
        {
            
            List<Leftovers> lf = new List<Leftovers>();
            var elem = lf.Select(x => x);
                foreach (var item in elem)
                {
                    foreach (var item2 in lf)
                    {
                        if (item.product_id == item2.product_id && item.location != item2.location)
                        {
                            item.leftCount += item2.leftCount;
                            item2.leftCount = 0;

                        }
                    }
                }
            var elem2 = lf.Where(x => x.leftCount >0).Select(x=>x);


            var result = elem2.Join(listProd, x => x.product_id, y => y.id, (x, y) => new { id = y.id, brand = y.brand, model = y.model, price = y.price, leftCount = x.leftCount }).OrderBy(x=>x.leftCount);

            foreach(var item in result)
            {
                Console.WriteLine($"#{item.id} {item.brand} - {item.model} - ${item.price}  - {item.leftCount} items left ");
            }
            try
            {
                listLeft.Clear();
                var invArr = File.ReadLines(@"D:\PMAcademy\HomeWork_3\Task_2\Inventory.csv").Skip(1);

                foreach (var line in invArr)
                {
                    string[] readed = line.Split(';');
                    Leftovers LF = new Leftovers(readed[0], readed[1], int.Parse(readed[2]));
                    listLeft.Add(LF);
                }
            }
            catch
            {
                Console.WriteLine("something hapend with file");
            }

        }
        public void LeftoversSortByDown()
        {
            List<Leftovers> lf = new List<Leftovers>();
            lf = listLeft;
            var elem = lf.Select(x => x);
            List<Leftovers> lad = new List<Leftovers>();
            foreach (var item in elem)
            {
                foreach (var item2 in lf)
                {
                    if (item.product_id == item2.product_id && item.location != item2.location)
                    {
                        item.leftCount += item2.leftCount;
                        item2.leftCount = 0;

                    }
                }
            }
            var elem2 = lf.Where(x => x.leftCount > 0).Select(x => x);

            var result = elem2.Join(listProd, x => x.product_id, y => y.id, (x, y) => new { id = y.id, brand = y.brand, model = y.model, price = y.price, leftCount = x.leftCount }).OrderByDescending(x => x.leftCount);

            foreach (var item in result)
            {
                Console.WriteLine($"#{item.id} {item.brand} - {item.model} - ${item.price} - {item.leftCount} items left ");
            }
            try
            {
                listLeft.Clear();
                var invArr = File.ReadLines(@"D:\PMAcademy\HomeWork_3\Task_2\Inventory.csv").Skip(1);

                foreach (var line in invArr)
                {
                    string[] readed = line.Split(';');
                    Leftovers LF = new Leftovers(readed[0], readed[1], int.Parse(readed[2]));
                    listLeft.Add(LF);
                }
            }
            catch
            {
                Console.WriteLine("something hapend with file");
            }

        }
        public void FindId()
        {
            
            Console.Write("input id  ");
            var input = Console.ReadLine();
            var result = listLeft.Where(x => x.product_id == input).Select(x => x).OrderByDescending(x=>x.leftCount);
            if(CheckNull.IsNullOrEmpty(result))
            {
                Console.WriteLine("we havent product with that id ");
                return;
            }
            foreach (var item in result)
            {
                Console.WriteLine($"in {item.location} - are {item.leftCount}  left ");
            }
            

        }
    }
   


}
