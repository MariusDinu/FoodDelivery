using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



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
                userRepository.Add(user);
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


        /**
         * Method: GET
         * Description: return existent user by username
         * Return:
         * Ok - return the user
         * BadRequest - if user doesnt't exist
         * */
        [HttpGet("get/{username}")]
        public IActionResult GetByUsername(string username)
        {
            User user = userRepository.GetByUsername(username);

            if (user == null)
            {
                return BadRequest(new { suces = false, message = "User with that username doesn't exist" });
            }
            return Ok(user);
        }


        /**
         * Method: Put
         * Description: update existent user
         * Return:
         * Ok - if the user has updated profile successfully
         * BadRequest - 
         *     1. The username exist
         *     2. The email exist
         *     3. Internal problem(Sql server,visual)
         */
        [HttpPut("update")]
        public IActionResult Update(int id, User user)
        {

            var userNameExisting = userRepository.VerifyUsername(user.UserName);
            if (userNameExisting == false)
            {
                return BadRequest(new { succes = false, message = "There is already an user with this name" });
            }

            var emailExisting = userRepository.VerifyEmail(user.Email);
            if (emailExisting == false)
            {
                return BadRequest(new { succes = false, message = "There is already an user with this email" });
            }

            bool response = userRepository.Update(id, user);
            if (response == false)
            {
                return BadRequest(new { succes = false, message = "Failed! Try again" });
            }

            return Ok(new { succes = true, message = "User updated" });
        }
    }
}