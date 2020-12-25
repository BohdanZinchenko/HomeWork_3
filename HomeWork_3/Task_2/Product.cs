using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class Product
    {
        public string id;
        public string brand;
        public string model;
        public int price;
        public Product()
        { }
        public Product(string id)
        {
            this.id = id;
        }
        public Product(string id, string brand, string model, int price)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.price = price;
        }
        public override string ToString()
        {
            return $"[{id}, {brand} , {model}, {price}]";
        }

    }
    public class DublicatProd : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (!(x is Product)) return false;
            if (!(y is Product)) return false;

            return x.id == y.id & x.brand == y.brand & x.model == y.model;
        }

        public int GetHashCode(Product obj)
        {
            return obj.id.GetHashCode() ^ obj.brand.GetHashCode() ^ obj.model.GetHashCode();
        }
    }

    public class ExceptP : Product, IEquatable<Leftovers>
    {

        public bool Equals(Leftovers other)
        {
            if (other is null)
                return false;
            return this.id == other.product_id;
        }
    }
}
