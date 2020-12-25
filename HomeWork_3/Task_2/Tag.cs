using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_2
{
    public class Tag
    {
        public string product_id;
        public string tag;
        public Tag()
        { }
        public Tag(string product_id, string tag)
        {
            this.product_id = product_id;
            this.tag = tag;
        }
        public override string ToString()
        {
            return $"[{product_id} , {tag}]";
        }

    }
    public class DublicatTag : IEqualityComparer<Tag>
    {
        public bool Equals( Tag x,  Tag y)
        {
            if (!(x is Tag)) return false;
            if (!(y is Tag)) return false;

            return x.product_id == y.product_id & x.tag == y.tag;
        }

        public int GetHashCode( Tag obj)
        {
            return obj.product_id.GetHashCode() ^ obj.tag.GetHashCode();
        }
    }
}
