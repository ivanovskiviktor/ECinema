using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Domain.DomainModels;
using TicketShop.Domain.Identity;
using TicketShop.Services.Interface;

namespace TicketShop.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly UserManager<TicketShopUser> userManager;

        public AdminController(IOrderService orderService, UserManager<TicketShopUser> userManager)
        {
            this._orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            return this._orderService.getAllOrders();
        }

        [HttpGet("[action]")]
        public async Task<List<Order>> GetOrdersForUserAsync()
        {
            TicketShopUser user = await this.userManager.GetUserAsync(User);
            return (List<Order>)this._orderService.getAllOrders().Where(o => o.UserId.Equals(user.Id));
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }

        [HttpPost("[action]")]
        public async Task<bool> ImportAllUsers(List<UserRegistrationImportDto> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                var userCheck = userManager.FindByEmailAsync(item.Email).Result;

                if (userCheck == null)
                {
                    var user = new TicketShopUser
                    {
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(user, item.Password).Result;
                    if(result.Succeeded)
                    {
                        await this.userManager.AddToRoleAsync(user, item.Role);
                    }
                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }

    }
}
