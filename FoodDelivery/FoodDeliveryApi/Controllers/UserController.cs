using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController : Controller
    {

        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /**
         * Method: POST
         * Description: add an user in database
         * Return:
         * Ok - if user is created successfully
         * BadRequest - if Json is null or user already exist (email/username)
         * */

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            if (user != null)
            {

                var exists = userRepository.VerifyExistence(user);
                if (exists)
                {
                    BadRequest(new { succes = false, message = "Email or Username already exist" });
                }
                var newUser = userRepository.Add(user);
                return Ok(new { succes = true });
            }
            return BadRequest(new { succes = false, message = "Null username" });
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
            IEnumerable<User> users = userRepository.GetAll();
            return Ok(users);
        }
    }
}