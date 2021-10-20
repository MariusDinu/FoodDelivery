using FoodDeliveryApi.Config;
using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;



namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController : Controller
    {

        private readonly IUserRepository userRepository;
        private readonly JwtConfig jwtConfig;
        public UserController(IUserRepository userRepository, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userRepository = userRepository;
            jwtConfig = optionsMonitor.CurrentValue;
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
                if (exists == false)
                {
                    return BadRequest(new { succes = false, message = "Email or Username already exist" });
                }
                var newUser = userRepository.Add(user);
                var jwtToken = JwtUser.Encode(newUser, jwtConfig);
                return Ok(new { succes = true, token = jwtToken, message = "Succes" });
            }
            return BadRequest(new { succes = false, message = "Null username" });
        }


        /**
        * Method: POST
        * Description: Login 
        * Return:
        * Ok - if user is login successfully
        * BadRequest - 
        *    1.if Json is null or user doesn't exist 
        *    2.if password doesn't match
        * */

        [HttpPost("auth")]
        public IActionResult Auth(User user)
        {
            if (user != null)
            {
                User userToLog = userRepository.GetByUsername(user.UserName);
                if (userToLog == null)
                {
                    return BadRequest(new { succes = false, message = "Username doesn't exist" });
                }

                bool verified = BCrypt.Net.BCrypt.Verify(user.Password, userToLog.Password);
                if (verified)
                {

                    var jwtToken = JwtUser.Encode(userToLog, jwtConfig);
                    return Ok(new { succes = true, token = jwtToken, message = "Login Successfully!" });
                }
                return BadRequest(new { succes = false, message = "Password doesn't match" });
            }
            return BadRequest(new { succes = false, message = "Null user" });
        }




        [HttpGet("profile")]
        public IActionResult GetByToken()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken == null)
            {
                return Unauthorized();
            }
            User user = userRepository.GetById(userFromToken.Id);

            if (user == null)
            {
                return BadRequest(new { success = false, message = "User with that username does not exist!" });
            }

            return Ok(user);
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
            Console.WriteLine("A intrat");
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
        [HttpPut("update/{id}")]
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