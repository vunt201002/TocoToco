using Microsoft.AspNetCore.Mvc;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.VnPay;

namespace TocoToco.PaymentController
{
    [Route("api/v1/payment/vnpay")]
    public class VnPayController : ControllerBase
    {
        private readonly IVnPayService _vpnPayService;

        public VnPayController(IVnPayService vnPayService)
        {
            _vpnPayService = vnPayService;
        }

        [HttpPost]
        public string CreatePaymentUrl([FromBody]OrderDTO orderDTO)
        {
            string paymentUrl = _vpnPayService.CreatePaymentUrl(orderDTO, HttpContext);

            return paymentUrl;
        }
    }
}
