using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class ProductController : ApiController
    {
        List<string> _products = new List<string>();

        public ProductController()
        {
            _products.Add("Chai");
            _products.Add("Espresso");
            _products.Add("Smoothie");
        }

        private Dictionary<string, string> GetProduct(int id)
        {
            return new Dictionary<string, string>
                {
                    { "id", id.ToString() }, 
                    { "name", _products[id] }
                };
        }

        private List<Dictionary<string, string>> GetProductList()
        {
            var productList = from id in Enumerable.Range(0, _products.Count) select GetProduct(id);
            return productList.ToList<Dictionary<string, string>>();
        }

        [HttpGet]
        public HttpResponseMessage ListItems()
        {
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Data = GetProductList()
                })
            };
        }

        [HttpGet]
        public HttpResponseMessage GetItem(int id)
        {
            if (id < _products.Count)
            {
                //return Request.CreateResponse(HttpStatusCode.OK, _products[id]);
                //JToken json = JObject.Parse("{ 'firstname' : 'Jason', 'lastname' : 'Voorhees' }");
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = GetProduct(id)
                    })
                };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new JsonContent(new
                    {
                        Message = "Product not found"
                    })
                };
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateItem([FromBody]string value)
        {
            dynamic json = JObject.Parse(value);
            var name = json.name.Value;
            _products.Add(name);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Data = GetProductList()
                })
            };
        }

        [HttpPut]
        public HttpResponseMessage UpdateItem(int id, [FromBody]string value)
        {
            if (id < _products.Count)
            {
                dynamic json = JObject.Parse(value);
                var name = json.name.Value;
                _products[id] = name;
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = GetProductList()
                    })
                };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new JsonContent(new
                    {
                        Message = "Product not found"
                    })
                };
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteItem(int id)
        {
            if (id < _products.Count)
            {
                _products.RemoveAt(id);
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = GetProductList()
                    })
                };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new JsonContent(new
                    {
                        Message = "Product not found"
                    })
                };
            }
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
