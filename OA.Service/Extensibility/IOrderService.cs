using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Service.Extensibility
{
    public interface IOrderService
    {
        Order Create(Order order, IEnumerable<Cart> cartItems);
    }
}
