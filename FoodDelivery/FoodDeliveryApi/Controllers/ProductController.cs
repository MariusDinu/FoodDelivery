using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("product/")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }



        /**
        * Method: POST
        * Description: add an product in database
        * Return:
        * Ok - if product is created successfully
        * BadRequest - if Json is null or restaurant doesnt exist
        * */

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            if (product != null)
            {
                var exists = productRepository.VerifyExistence(product);
                if (exists == false)
                {
                    return BadRequest(new { succes = false, message = "Product already exist in restaurant" });
                }
                productRepository.Add(product);
                return Ok(new { succes = true });
            }
            return BadRequest(new { succes = false, message = "Null product" });
        }



        /**
         * Method: GET
         * Description: return all existent users
         * Return:
         * Ok - with a list of users
         * */
        [HttpGet("get")]
        public IActionResult GetAll()
        {
            IEnumerable<Product> products = productRepository.GetAll();
            return Ok(products);
        }



        /**
         * Method: GET
         * Description: return existents products by restaurant id
         * Return:
         * Ok - return the products
         * BadRequest - if restaurant doesnt't exist
         * */
        [HttpGet("get/{id:int}")]
        public IActionResult GetByRestaurantId(int id)
        {
            IEnumerable<Product> product = productRepository.GetByRestaurantId(id);

            if (product == null)
            {
                return BadRequest(new { suces = false, message = "Restaurant with that id doesn't exist" });
            }
            return Ok(product);
        }


        /**
        * Method: GET
        * Description: return existents products by restaurant id
        * Return:
        * Ok - return the products
        * BadRequest - if restaurant doesnt't exist
        * */
        [HttpGet("get/{name}")]
        public IActionResult GetByRestaurantName(string name)
        {
            IEnumerable<Product> product = productRepository.GetByRestaurantName(name);

            if (product == null)
            {
                return BadRequest(new { suces = false, message = "Restaurant with that name doesn't exist" });
            }
            return Ok(product);
        }

        /**
         * Method: Put
         * Description: update existent product
         * Return:
         * Ok - if the product has updated profile successfully
         * BadRequest - 
         *     1. The name exist
         *     2. Internal problem(Sql server,visual)
         */
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Product product)
        {
            var productExisting = productRepository.VerifyExistence(product);
            if (productExisting == false)
            {
                return BadRequest(new { succes = false, message = "There is already an product with this name in your restaurant" });
            }

            bool response = productRepository.Update(id, product);
            if (response == false)
            {
                return BadRequest(new { succes = false, message = "Failed! Try again" });
            }

            return Ok(new { succes = true, message = "Product updated" });
        }
    }
}
