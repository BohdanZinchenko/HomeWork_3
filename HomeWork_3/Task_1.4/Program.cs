using System;
using System.Collections.Generic;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1.4 , Finding a mistake in brackets ");
            Console.WriteLine("Student of Pm Tech Academy Zicnhenko Bogdan");
            Console.WriteLine("Input a string with brackets and program its will be cheked for the right brakets");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            string find;
            while (true)
            {
                Console.WriteLine("Input string or Exit for leave program");
                find = Console.ReadLine();
                if(find == "Exit")
                { return; }

                if (IsValid(find))
                {
                    Console.WriteLine("all is right ");
                }
                else
                {
                    Console.WriteLine("Something went wrong\n ");
                }
            }
        }
        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            int i=-1;
            foreach (var c in s)
            {
                i++;
               
                switch (c)
                {
                    case '{':
                    case '(':
                    case '[':
                    case '<':
                        stack.Push(c);
                        break;

                    case '}':
                        if (stack.Count == 0)
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        if (stack.Pop() != '{')
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0)
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        if (stack.Pop() != '[')
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        break;
                    case ')':
                        if (stack.Count == 0)
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        if (stack.Pop() != '(')
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        break;
                    case '>':
                        if (stack.Count == 0)
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        if (stack.Pop() != '<')
                        {
                            Console.WriteLine($"Error was detacted in {i} position");
                            return false;
                        }
                        
                        break;
                       
                }
            }
            if (stack.Count != 0)
            {
                Console.WriteLine($"Error was detacted in {i} position  the bracket Not Closed ");
            }
            
            return stack.Count == 0;
        }
    }
}
