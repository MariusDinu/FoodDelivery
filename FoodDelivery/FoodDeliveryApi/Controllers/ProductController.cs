using FoodDeliveryApi.Config;
using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("product/")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IImageHelper imageHelper;

        public ProductController(IProductRepository productRepository,IRestaurantRepository restaurantRepository, IImageHelper imageHelper)
        {
            this.productRepository = productRepository;
            this.restaurantRepository = restaurantRepository;
            this.imageHelper = imageHelper;
        }



        /**
        * Method: POST
        * Description: add an product in database
        * Return:
        * Ok - if product is created successfully
        * BadRequest - if Json is null or restaurant doesnt exist
        * */

        [HttpPost("add")]
        public IActionResult Add(ProductToAdd product)
        {
            Restaurant restaurant = restaurantRepository.GetById(product.IdRestaurant);
            if (restaurant != null)
            {
                Product productNew = new Product(product.IdRestaurant, product.Name, product.Price, product.Description);
                if (product != null)
                {
                    var exists = productRepository.VerifyExistence(productNew);
                    if (exists == false)
                    {
                        return BadRequest(new { succes = false, message = "Product already exist in restaurant" });
                    }
                    productNew.Path = imageHelper.AddImageProduct(product.ImageData, product.IdRestaurant, product.Name);

                    productRepository.Add(productNew);
                    return Ok(new { succes = true });
                }
                return BadRequest(new { succes = false, message = "Null product" });
            }
            return BadRequest(new { succes = false, message = "Null restaurant" });
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
        [HttpGet("get/restaurant/{id:int}")]
        public IActionResult GetByRestaurantId(int id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken == null)
            {
                return Unauthorized();
            }
            List<ProductToAdd> product = productRepository.GetByRestaurantId(id);

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
        [HttpGet("get/{id:int}")]
        public IActionResult GetById(int id)
        {
            ProductToAdd product = productRepository.GetById(id);

            if (product == null)
            {
                return BadRequest(new { suces = false, message = "Product with that id doesn't exist" });
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
