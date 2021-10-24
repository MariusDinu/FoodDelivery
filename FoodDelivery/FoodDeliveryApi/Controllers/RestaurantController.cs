using FoodDeliveryApi.Config;
using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("restaurant/")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IImageHelper imageHelper;
        public RestaurantController(IRestaurantRepository restaurantRepository,IImageHelper imageHelper)
        {
            this.restaurantRepository = restaurantRepository;
            this.imageHelper = imageHelper;
        }


        /**
         * Method: POST
         * Description: add an restaurant in database
         * Return:
         * Ok - if restaurant is created successfully
         * BadRequest - if Json is null or restaurant already exist (restaurant name)
         * */

        [HttpPost("add")]
        public IActionResult Add(RestaurantToAdd restaurant)
        {
            Restaurant restaurantNew = new Restaurant(restaurant.RestaurantName, restaurant.Street, restaurant.StreetNumber,restaurant.Building);
            if (restaurantNew != null)
            {
                var exists = restaurantRepository.VerifyExistence(restaurantNew);
                if (exists == false)
                {
                    return BadRequest(new { succes = false, message = "This restaurant already exist" });
                }

               
                restaurantNew.Path = imageHelper.AddImageRestaurant(restaurant.ImageData,restaurant.RestaurantName);

                restaurantRepository.Add(restaurantNew);
                return Ok(new { succes = true });
            }
            return BadRequest(new { succes = false, message = "Null restaurant name" });
        }



        /**
         * Method: GET
         * Description: return all existent restaurants
         * Return:
         * Ok - with a list of restaurants
         * */
        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken == null)
            {
                return Unauthorized();
            }
            List<RestaurantToAdd> restaurants = restaurantRepository.GetAll();
            
            return Ok(restaurants);
        }


        /**
         * Method: GET
         * Description: return restaurant by name
         * Return:
         * Ok - return the restaurant
         * BadRequest - if restaurant doesnt't exist
         * */
        [HttpGet("get/{name}")]
        public IActionResult GetByName(string name)
        {
            Restaurant restaurant = restaurantRepository.GetByName(name);

            if (restaurant == null)
            {
                return BadRequest(new { suces = false, message = "Restaurant with that name doesn't exist" });
            }
            return Ok(restaurant);
        }


        /**
        * Method: GET
        * Description: return restaurant by id
        * Return:
        * Ok - return the restaurant
        * BadRequest - if restaurant doesnt't exist
        * */
        [HttpGet("get/{id:int}")]
        public IActionResult GetById(int id)
        {
            Restaurant restaurant = restaurantRepository.GetById(id);
            string imageData = imageHelper.ReadImage(restaurant.Path);
            restaurant.Path = imageData;
            if (restaurant == null)
            {
                return BadRequest(new { suces = false, message = "Restaurant with that id doesn't exist" });
            }
            return Ok(restaurant);
        }

        /**
        * Method: Put
        * Description: update existent restaurant
        * Return:
        * Ok - if the restaurant has updated profile successfully
        * BadRequest - 
        *     1. The name exist
        *     2. Internal problem(Sql server,visual)
        */
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Restaurant restaurant)
        {
            var restaurantNameExisting = restaurantRepository.VerifyExistence(restaurant);
            if (restaurantNameExisting == false)
            {
                return BadRequest(new { succes = false, message = "There is already a restaurant with this name" });
            }

            bool response = restaurantRepository.Update(id, restaurant);
            if (response == false)
            {
                return BadRequest(new { succes = false, message = "Failed! Try again" });
            }

            return Ok(new { succes = true, message = "Restaurant updated" });
        }
    }
}