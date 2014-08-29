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
        private ProductRepository _productRepo;

        public ProductController()
        {
            _productRepo = ProductRepository.Instance;
        }

        [HttpGet]
        public HttpResponseMessage ListItems()
        {
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Data = _productRepo.GetProductList()
                })
            };
        }

        [HttpGet]
        public HttpResponseMessage GetItem(int id)
        {
            var product = _productRepo.GetProduct(id);
            if (product != null)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = product
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
        public HttpResponseMessage CreateItem([FromBody]dynamic json)
        {
            var name = json.name.Value;
            _productRepo.CreateProduct(name);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(new
                {
                    Data = _productRepo.GetProductList()
                })
            };
        }

        [HttpPut]
        public HttpResponseMessage UpdateItem(int id, [FromBody]dynamic json)
        {
            var name = json.name.Value;
            bool result = _productRepo.UpdateProduct(id, name);
            if (result)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = _productRepo.GetProductList()
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
            bool result = _productRepo.DeleteProduct(id);
            if (result)
            {
                return new HttpResponseMessage()
                {
                    Content = new JsonContent(new
                    {
                        Data = _productRepo.GetProductList()
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
}
