using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApi.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDeliveryContext context;

        public OrderRepository(FoodDeliveryContext context)
        {
            this.context = context;
        }

        Order IOrderRepository.Add(Order order)
        {
            order.CreatedAt = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        IEnumerable<Order> IOrderRepository.GetAll()
        {
            return context.Orders;
        }

        Order IOrderRepository.GetById(int id)
        {
            Order order = context.Orders.Where(order => order.Id == id).FirstOrDefault();
            return order;
        }

        IEnumerable<Order> IOrderRepository.GetByRestaurantId(int id)
        {
            IEnumerable<Order> orders = context.Orders.Where(order => order.IdRestaurant == id);
            return orders;
        }

        IEnumerable<Order> IOrderRepository.GetByUserId(int id)
        {
            IEnumerable<Order> orders = context.Orders.Where(order => order.IdUser == id);
            return orders;
        }

        bool IOrderRepository.Update(int id, Order order)
        {
            Order orderUpdate = context.Orders.FirstOrDefault(o => o.Id == id);
            if (orderUpdate != null)
            {
                orderUpdate.Location = order.Location;
                orderUpdate.Price = order.Price;
                orderUpdate.Products = order.Products;
                orderUpdate.Status = order.Status;
                orderUpdate.UpdatedAt = DateTime.Now;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        bool IOrderRepository.VerifyExistence(Order order)
        {
            Order existingOrder = context.Orders.Where(o => (o.IdUser == order.IdUser &&
                                                             o.IdRestaurant == order.IdRestaurant &&
                                                             DateTime.Compare(o.CreatedAt, order.CreatedAt) == 0)).FirstOrDefault();

            return existingOrder == null;
        }

    }
}
