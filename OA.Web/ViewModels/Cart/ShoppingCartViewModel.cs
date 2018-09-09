using OA.Domain.Entities;
using System.Collections.Generic;

namespace OA.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Cart> CartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}
