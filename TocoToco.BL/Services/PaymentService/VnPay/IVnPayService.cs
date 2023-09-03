using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.VnPay.Request;
using TocoToco.BL.Services.PaymentService.VnPay.Response;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.PaymentService.VnPay
{
    public interface IVnPayService
    {
        public string CreatePaymentUrl(OrderDTO model, HttpContext context);
        public PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
