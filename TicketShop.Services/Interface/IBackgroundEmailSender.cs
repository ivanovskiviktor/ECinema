using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Services.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
