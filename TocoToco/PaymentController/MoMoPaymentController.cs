using Microsoft.AspNetCore.Mvc;
using TocoToco.Base;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.MoMo;
using TocoToco.Common.Models;

namespace TocoToco.PaymentController
{
    [Route("api/v1/payment/momo")]
    public class MoMoPaymentController : BasePaymentController
    {
        private readonly IMoMoPaymentService _moMoPaymentService;

        public MoMoPaymentController(IMoMoPaymentService moMoPaymentService)
        {
            _moMoPaymentService = moMoPaymentService;
        }

        /// <summary>
        /// hàm thanh toán qua momo
        /// gọi đến service
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<MomoCreatePaymentResponseModel></returns>
        /// created by: ntvu (01/09/2023)
        [HttpPost]
        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderDTO order)
        {
            MomoCreatePaymentResponseModel response =
                await _moMoPaymentService.CreatePaymentAsync(order);

            return response;
        }
    }
}
