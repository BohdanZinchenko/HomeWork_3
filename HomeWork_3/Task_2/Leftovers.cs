using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_2
{
    public class Leftovers
    {
        public string product_id;
        public string location;
        public int leftCount;
        public Leftovers()
        {

        }
        public Leftovers(string product_id, string location, int leftCount)
        {
            this.product_id = product_id;
            this.location = location;
            this.leftCount = leftCount;
        }
        public override string ToString()
        {
            return $"[{product_id} , {location} , {leftCount} ]";
        }
    }
    public class DublicatLeftovers : IEqualityComparer<Leftovers>
    {
        public bool Equals([AllowNull] Leftovers x, [AllowNull] Leftovers y)
        {
            
                if (!(x is Leftovers)) return false;
                if (!(y is Leftovers)) return false;

                return x.product_id == y.product_id & x.location == y.location & x.leftCount ==y.leftCount;
            
        }

        public int GetHashCode([DisallowNull] Leftovers obj)
        {
            return obj.leftCount.GetHashCode() ^ obj.product_id.GetHashCode() ^ obj.location.GetHashCode();
        }
    }

    public class ExceptL : Leftovers ,IEquatable<Leftovers>
    {
        
        public bool Equals([AllowNull] Leftovers other)
        {
            if (other is null)
                return false;
            return this.product_id == other.product_id && this.location == other.location && this.leftCount == other.leftCount;
        }
    }

}
