using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1.2 , List of Cs Players");
            Console.WriteLine("Student of Pm Tech Academy Zicnhenko Bogdan");
            Console.WriteLine("Show list of all Cs players ");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            List<CsPlayer> listplayer = new List<CsPlayer>();
            listplayer.Add(new CsPlayer{ age = 29, firstName = "Ivan",lastName = "Ivanov",rank = PlayerRank.Captain});
            listplayer.Add(new CsPlayer { age = 19, firstName = "Peter", lastName = "Petrenko", rank = PlayerRank.Private });
            listplayer.Add(new CsPlayer { age = 59, firstName = "Ivan", lastName = "Ivanov", rank = PlayerRank.General });
            listplayer.Add(new CsPlayer { age = 52, firstName = "Ivan", lastName = "Snezko", rank = PlayerRank.Lieutenant });
            listplayer.Add(new CsPlayer { age = 34, firstName = "Alex", lastName = "Zeshko", rank = PlayerRank.Colonel });
            listplayer.Add(new CsPlayer { age = 29, firstName = "Ivan", lastName = "Ivanenko", rank = PlayerRank.Captain });
            listplayer.Add(new CsPlayer { age = 19, firstName = "Peter", lastName = "Petrenko", rank = PlayerRank.Private });
            listplayer.Add(new CsPlayer { age = 34, firstName = "Vasiliy", lastName = "Sokol", rank = PlayerRank.Major });
            listplayer.Add(new CsPlayer { age = 31, firstName = "Alex", lastName = "Alexeenko", rank = PlayerRank.Major });




            var NoDublicatListplayer = listplayer.Distinct(new Dublicats());
            listplayer = NoDublicatListplayer.ToList();
            Console.WriteLine("List sorted by AGE");
            listplayer.Sort(new AgeSort());
            listplayer.ForEach(value => Console.WriteLine(value.ToString()));
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("List sorted by FIO");
            listplayer.Sort(new FioSort());
            listplayer.ForEach(value => Console.WriteLine(value.ToString()));
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("List sorted by RANK");
            listplayer.Sort(new RankSort());
            listplayer.ForEach(value => Console.WriteLine(value.ToString()));
            Console.WriteLine("---------------------------------------------");
            
        }
    }
    interface IPlayer
    {
        public int Age { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PlayerRank Rank { get; }
    }
    
    public enum PlayerRank
    {
        Private = 2,
        Lieutenant = 21,
        Captain = 25,
        Major = 29,
        Colonel = 33,
        General = 39
    }
   
    public class CsPlayer : IPlayer 
    {
        public int age;
        public string firstName;
        public string lastName;
        public PlayerRank rank;
        public  CsPlayer()
        {
        }
        public  int Age => age; 
        public string FirstName =>  FirstName;
        public string LastName => LastName;
        PlayerRank IPlayer.Rank => rank;

        public override string ToString()
        {
           return $"[{age},{firstName},{lastName},{rank}]";
        }
    }
    public class AgeSort: IComparer<CsPlayer>
    {
        
        public int Compare([AllowNull] CsPlayer x, [AllowNull] CsPlayer y)
        {
            if(x.age.CompareTo(y.age) != 0)
            {
                return x.age.CompareTo(y.age);
            }
            return 0;
        }
        public int SortByAge(int x,int y)
        {
            return x.CompareTo(y);
        }
    }
    public class FioSort : IComparer<CsPlayer>
    {
       
        public int Compare([AllowNull] CsPlayer x, [AllowNull] CsPlayer y)
        {
            if ((x.firstName+x.lastName).CompareTo(y.firstName+y.lastName) != 0)
            {
                return (x.firstName + x.lastName).CompareTo(y.firstName + y.lastName);
            }
            return 0;
        }
        public int SortByFIO(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
    public class RankSort : IComparer<CsPlayer>
    {
        
        public int Compare([AllowNull] CsPlayer x, [AllowNull] CsPlayer y)
        {
            if (x.rank.CompareTo(y.rank) != 0)
            {
                return x.rank.CompareTo(y.rank);
            }
            return 0;
        }
        public int SortByAge(int x, int y)
        {
            return x.CompareTo(y);
        }

    }
    public class Dublicats : IEqualityComparer<CsPlayer>
    {

        
        public bool Equals(CsPlayer x, CsPlayer y)
        {
            if (!(x is CsPlayer)) return false;
            if (!(y is CsPlayer)) return false;

            return x.age == y.age & x.firstName == y.firstName & x.lastName == y.lastName & x.rank == y.rank;
        }
        public int GetHashCode(CsPlayer obj)
        {
            return obj.age.GetHashCode() ^ obj.firstName.GetHashCode() ^ obj.lastName.GetHashCode() ^ obj.rank.GetHashCode();
        }
    }
}

