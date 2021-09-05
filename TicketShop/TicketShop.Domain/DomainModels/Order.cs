using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.Domain.Identity;

namespace TicketShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public TicketShopUser User { get; set; }

        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}
