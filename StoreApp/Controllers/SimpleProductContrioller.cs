using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class SimpleProductController : ApiControllerAttribute 
    {
        List<Products> products = new List<Products>();

        public SimpleProductController() { }

        public SimpleProductController(List<Products> products)
        {
            this.products = products;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return products;
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await Task.FromResult(GetAllProducts());
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        private IHttpActionResult Ok(List<Products> products)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<IHttpActionResult> GetProductAsync(int id)
        {
            return await Task.FromResult(GetProduct(id));
        }

    }
}
