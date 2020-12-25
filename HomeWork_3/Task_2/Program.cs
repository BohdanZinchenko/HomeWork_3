using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace Task_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Task 2 , ERP Bot  ");
            Console.WriteLine("Student of Pm Tech Academy Zicnhenko Bogdan");
            Console.WriteLine("Chouse one of the menu paragraph for this input the number of paragraph");
            Console.WriteLine("-----------------------------------------------------------------------------");







            List<Product> listProd = new List<Product>();
            List<Tag> listTag= new List<Tag>();
            List<Leftovers> listLeft = new List<Leftovers>();

            var prodArr = File.ReadLines(@"D:\PMAcademy\HomeWork_3\Task_2\Products.csv").Skip(1);
            foreach (var line in prodArr)
            {
                
                string[] elem = line.Split(';');
                Product pr = new Product(elem[0],elem[1],elem[2],int.Parse(elem[3]));
                listProd.Add(pr);
            }
            
            var invArr = File.ReadLines(@"D:\PMAcademy\HomeWork_3\Task_2\Inventory.csv").Skip(1);

            foreach (var line in invArr)
            {
                string[] elem = line.Split(';');
                Leftovers lf = new Leftovers(elem[0],elem[1],int.Parse(elem[2]));
                listLeft.Add(lf);
            }

            var tagArr = File.ReadLines(@"D:\PMAcademy\HomeWork_3\Task_2\Tags.csv").Skip(1);
            foreach (var line in tagArr)
            {
                string[] elem = line.Split(';');
                Tag tg = new Tag(elem[0], elem[1]);
                listTag.Add(tg);
            }
            var NoDublProd = listProd.Distinct(new DublicatProd());
            listProd = NoDublProd.ToList();
            var NoDublTag = listTag.Distinct(new DublicatTag());
            listTag = NoDublTag.ToList();
            var NoDublLeftovers = listLeft.Distinct(new DublicatLeftovers());
            listLeft = NoDublLeftovers.ToList();

            WorkSpace workSpace = new WorkSpace(listProd, listTag, listLeft);
            workSpace.ShowMenu();


        }
    }

    
   
    

   
}
