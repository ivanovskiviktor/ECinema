using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.Domain.Identity;

namespace TicketShop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<TicketShopUser> GetAll();
        TicketShopUser Get(string id);
        void Insert(TicketShopUser entity);
        void Update(TicketShopUser entity);
        void Delete(TicketShopUser entity);
    }
}
