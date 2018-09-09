using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using OA.Service.Extensibility;
using System.Collections.Generic;

namespace OA.Service
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Create(Order order, IEnumerable<Cart> cartItems)
        {
            decimal orderTotal = 0;

            foreach (Cart item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.Id,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Album.Price);
                order.OrderDetails = new List<OrderDetail>();
                order.OrderDetails.Add(orderDetail);

            }

            orderRepository.Add(order);

            return order;
        }
    }
}
