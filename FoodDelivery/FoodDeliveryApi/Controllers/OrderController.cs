using FoodDeliveryApi.Config;
using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApi.Controllers
{
    [ApiController]
    [Route("order/")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderProductsRepository orderProductsRepository;
        public OrderController(IOrderRepository orderRepository, IOrderProductsRepository orderProductsRepository)
        {
            this.orderRepository = orderRepository;
            this.orderProductsRepository = orderProductsRepository;
        }



        /**
         * Method: POST
         * Description: add an order in database
         * Return:
         * Ok - if order is created successfully
         * BadRequest - if Json is null or order already exist 
         * */

        [HttpPost("add")]
        public IActionResult Add(FullOrder fullOrder)
        {
            if (fullOrder == null) return BadRequest(new { succes = false, message = "Null order" });
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken != null)
            {
                fullOrder.order.IdUser = userFromToken.Id;
                bool exists = orderRepository.VerifyExistence(fullOrder.order);
                if (exists == false)
                {
                    return BadRequest(new { succes = false, message = "Order already exist" });
                }

                Order orderNew = orderRepository.Add(fullOrder.order);
                orderProductsRepository.Add(fullOrder.orderProducts, orderNew.Id);
                return Ok(new { succes = true, message = "Order inserted" });
            }
            return BadRequest(new { succes = false, message = "Null user" });
        }


        /**
        * Method: GET
        * Description: return all existent orders
        * Return:
        * Ok - with a list of orders
        * */
        [HttpGet("get")]
        public IActionResult GetAll()
        {
            IEnumerable<Order> orders = orderRepository.GetAll();
            return Ok(orders);
        }


        [HttpGet("get/{id:int}")]
        public IActionResult GetById(int id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken != null)
            {
                Order order = orderRepository.GetById(id);
                IEnumerable<OrderProducts> orderProducts = orderProductsRepository.GetAllById(order.Id);
                FullOrder fullOrder = new FullOrder(order, orderProducts.ToList());
                if (order != null) { return Ok(fullOrder); }
                return BadRequest(new { suces = false, message = "Order with that id doesn't exist" });
            }
            return BadRequest(new { suces = false, message = "User with that id doesn't exist" });
        }

        /**
         * Method: GET
         * Description: return existents orders by restaurant id
         * Return:
         * Ok - return the orders
         * BadRequest - if restaurant doesnt't exist
         * */
        [HttpGet("get/restaurant/{id:int}")]
        public IActionResult GetByRestaurantId(int id)
        {

            IEnumerable<Order> orders = orderRepository.GetByRestaurantId(id);

            if (orders == null)
            {
                return BadRequest(new { suces = false, message = "Restaurant with that id doesn't exist" });
            }
            return Ok(orders);
        }


        /**
         * Method: GET
         * Description: return existents orders by user id
         * Return:
         * Ok - return the orders
         * BadRequest - if user doesnt't exist
         * */
        [HttpGet("get/user")]
        public IActionResult GetByUserId()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            User userFromToken = JwtUser.Decode(accessToken);
            if (userFromToken != null)
            {
                IEnumerable<Order> orders = orderRepository.GetByUserId(userFromToken.Id);

                if (orders == null)
                {
                    return BadRequest(new { suces = false, message = "User with that id doesn't exist" });
                }
                return Ok(orders);
            }
            return BadRequest(new { suces = false, message = "User with that id doesn't exist" });
        }

        /**
        * Method: Put
        * Description: update existent order
        * Return:
        * Ok - if the order has updated successfully
        * BadRequest - 
        *     1. The order doesn't exist
        *     2. Internal problem(Sql server,visual)
        */
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Order order)
        {
            var orderExisting = orderRepository.VerifyExistence(order);
            if (orderExisting)
            {
                return BadRequest(new { succes = false, message = "This order doesn't exist" });
            }

            bool response = orderRepository.Update(id, order);
            if (response == false)
            {
                return BadRequest(new { succes = false, message = "Failed! Try again" });
            }

            return Ok(new { succes = true, message = "Product updated" });
        }
    }
}
