using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest
{
    public sealed class ProductRepository
    {
        private static readonly Lazy<ProductRepository> lazy =
            new Lazy<ProductRepository>(() => new ProductRepository());

        public static ProductRepository Instance { get { return lazy.Value; } }

        private List<string> _products;

        private ProductRepository()
        {
            _products = new List<string>();

            _products.Add("Chai");
            _products.Add("Espresso");
            _products.Add("Smoothie");
        }

        public Dictionary<string, string> GetProduct(int id)
        {
            if (id < _products.Count)
            {
                return new Dictionary<string, string>
                {
                    { "id", id.ToString() }, 
                    { "name", _products[id] }
                };
            }
            else
            {
                return null;
            }
        }

        public List<Dictionary<string, string>> GetProductList()
        {
            var productList = from id in Enumerable.Range(0, _products.Count) select GetProduct(id);
            return productList.ToList<Dictionary<string, string>>();
        }

        public void CreateProduct(string name)
        {
            _products.Add(name);
        }

        public bool UpdateProduct(int id, string name)
        {
            if (id < _products.Count)
            {
                _products[id] = name;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            if (id < _products.Count)
            {
                _products.RemoveAt(id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}