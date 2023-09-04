using Microsoft.AspNetCore.Mvc;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.ZaloPay;
using TocoToco.BL.Services.PaymentService.ZaloPay.Response;

namespace TocoToco.PaymentController
{
    [Route("api/v1/payment/zalopay")]
    public class ZaloPayController : ControllerBase
    {
        private readonly IZaloPayService _zaloPayService;

        public ZaloPayController(IZaloPayService zaloPayService)
        {
            _zaloPayService = zaloPayService;
        }

        [HttpPost]
        public CreateZalopayPayResponse CreatePayment([FromBody]OrderDTO orderDTO)
        {
            CreateZalopayPayResponse paymentUrl = _zaloPayService.CreatePayment(orderDTO);

            return paymentUrl;
        }
    }
}
