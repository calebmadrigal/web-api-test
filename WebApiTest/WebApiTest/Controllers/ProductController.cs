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

        [HttpGet]
        public IHttpActionResult ListItems()
        {
            // Demonstrating the IHttpActionResult method
            //
            // Alternatively, this method could return HttpResponseMessage and would
            // call return Request.CreateResponse(HttpStatusCode.OK, _products.ToArray())
            return Ok(_products.ToArray());
        }

        [HttpGet]
        public HttpResponseMessage GetItem(int id)
        {
            if (id < _products.Count)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _products[id]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateItem([FromBody]string value)
        {
            _products.Add(value);
            return Request.CreateResponse(HttpStatusCode.OK, _products.ToArray());
        }

        [HttpPut]
        public HttpResponseMessage UpdateItem(int id, [FromBody]string value)
        {
            _products[id] = value;
            return Request.CreateResponse(HttpStatusCode.OK, _products.ToArray());
        }

        [HttpDelete]
        public HttpResponseMessage DeleteItem(int id)
        {
            if (id < _products.Count)
            {
                _products.RemoveAt(id);
                return Request.CreateResponse(HttpStatusCode.OK, _products.ToArray());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
