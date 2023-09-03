using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.Common.Models;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.PaymentService.MoMo
{
    public interface IMoMoPaymentService
    {
        /// <summary>
        /// hàm gửi request lên momo
        /// để lấy url thanh toán
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<MomoCreatePaymentResponseModel></returns>
        /// created by: ntvu (01/09/2023)
        public Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderDTO order);
    }
}
