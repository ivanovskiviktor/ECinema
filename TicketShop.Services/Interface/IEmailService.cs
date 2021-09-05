using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Domain.DomainModels;

namespace TicketShop.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
