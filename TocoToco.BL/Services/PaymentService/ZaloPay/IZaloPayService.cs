using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.ZaloPay.Response;

namespace TocoToco.BL.Services.PaymentService.ZaloPay
{
    public interface IZaloPayService
    {
        public CreateZalopayPayResponse CreatePayment(OrderDTO orderDTO);
    }
}
