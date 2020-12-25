using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1.2 , Array statistic by Linq");
            Console.WriteLine("Student of Pm Tech Academy Zicnhenko Bogdan");
            Console.WriteLine("Input array of of integer elemnts , and program will show all statistic information ");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            int sum = 0;
            int min = 0;
            int max = 0;
            double avarage;
            double midle_avarage;
            string[] arr=null;
            IEnumerable<int> intarr;
          
            while (true)
            {
                string input = Console.ReadLine();
                if(input =="")
                {
                    Console.WriteLine("Error input , try again");
                    continue;
                }
                arr = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    intarr = arr.Select(x => x.Trim()).OrderBy(x=> int.Parse(x)).Select(x => int.Parse(x)).Distinct();
                    sum = arr.Select(x => x.Trim()).Select(x => int.Parse(x)).Sum();
                    min = arr.Select(x => x.Trim()).Select(x => int.Parse(x)).Min();
                    max = arr.Select(x => x.Trim()).Select(x => int.Parse(x)).Max();
                    avarage = arr.Select(x => x.Trim()).Select(x => int.Parse(x)).Average();
                    midle_avarage = arr.Select(x=>x.Trim()).Select(x=>Math.Pow(int.Parse(x)- avarage, 2)).Average();
                }
                catch
                {
                    Console.WriteLine("Error input , try again");
                    continue;
                }
                Console.WriteLine("Integer array ");
                foreach (var item in intarr)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Array Stat ");
                Console.WriteLine($" Sum = {sum}");
                Console.WriteLine($" Min = {min}");
                Console.WriteLine($" Max = {max}");
                Console.WriteLine($" Avarage = {avarage}");
                Console.WriteLine($" Standard Deviation = {Math.Sqrt(midle_avarage)}");
                break;

            }
            



        }
    }
}
