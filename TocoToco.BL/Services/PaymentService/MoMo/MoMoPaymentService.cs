using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.Common.Models;
using TocoToco.DL.Entities;
using TocoToco.DL.Migrations;

namespace TocoToco.BL.Services.PaymentService.MoMo
{
    public class MoMoPaymentService : IMoMoPaymentService
    {
        private readonly IConfiguration _configuration;

        public MoMoPaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// hàm mã hóa với sha256
        /// </summary>
        /// <param name="message"></param>
        /// <param name="secretKey"></param>
        /// <returns>string</returns>
        /// created by: ntvu (01/09/2023)
        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }

        /// <summary>
        /// hàm gửi request lên momo
        /// để lấy url thanh toán
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Task<MomoCreatePaymentResponseModel></returns>
        /// created by: ntvu (01/09/2023)
        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderDTO order)
        {
            string momoApiUrl = _configuration["Momo:PaymentUrl"];
            string secretKey = _configuration["Momo:SecretKey"];
            string accessKey = _configuration["Momo:AccessKey"];
            string returnUrl = _configuration["Momo:ReturnUrl"];
            string notifyUrl = _configuration["Momo:IpnUrl"];
            string partnerCode = _configuration["Momo:PartnerCode"];
            string requestType = _configuration["Momo:RequestType"];

            Guid requestId = Guid.NewGuid();

            string rawHash = "accessKey=" + accessKey +
                "&amount=" + order.TotalPrice.ToString() +
                "&extraData=" + "" +
                "&ipnUrl=" + notifyUrl +
                "&orderId=" + order.Id +
                "&orderInfo=" + order.Note +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + returnUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType
            ;


            var signature = ComputeHmacSha256(rawHash, secretKey);

            var client = new RestClient(momoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            // Create an object representing the request data
            //var requestData = new
            //{
            //    accessKey,
            //    partnerCode,
            //    requestType,
            //    notifyUrl,
            //    returnUrl,
            //    orderId = order.Id,
            //    amount = order.TotalPrice.ToString(),
            //    orderInfo = order.Note,
            //    requestId,
            //    extraData = "",
            //    signature
            //};

            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", order.TotalPrice.ToString() },
                { "orderId", order.Id },
                { "orderInfo", order.Note },
                { "redirectUrl", returnUrl },
                { "ipnUrl", notifyUrl },
                { "lang", "vn" },
                { "extraData", "" },
                { "requestType", requestType },
                { "signature", signature }

            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(message), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            var content = JsonConvert
                .DeserializeObject<MomoCreatePaymentResponseModel>(response.Content);

            return content;
        }
    }
}
