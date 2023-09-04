using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TocoToco.BL.DTOs.OrderDTOs;
using TocoToco.BL.Services.PaymentService.ZaloPay.Response;

namespace TocoToco.BL.Services.PaymentService.ZaloPay
{
    public class ZaloPayService : IZaloPayService
    {
        private readonly IConfiguration _configuration;

        public ZaloPayService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static String HmacSHA256(string inputData, string key)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;
            }
        }

        public CreateZalopayPayResponse CreatePayment(OrderDTO orderDTO)
        {
            // lấy ra thông tin config của zalopay
            var AppId = _configuration["ZaloPay:AppId"];
            var AppTransId = orderDTO.Id;
            var AppUser = _configuration["ZaloPay:AppUser"];
            var Amount = (long)orderDTO.TotalPrice;
            var AppTime = ZaloPayService.GetTimeStamp(DateTime.Now);

            // tạo raw data để hash signature
            var data = AppId + "|" + AppTransId + "|" + AppUser + "|" + Amount + "|"
              + AppTime + "|" + "|";

            // dùng hàm hash tạo signature
            var Mac = ZaloPayService.HmacSHA256(data, _configuration["ZaloPay:Key2"]);

            // tạo data để gửi request lên zalopay
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("appid", AppId.ToString());
            keyValuePairs.Add("appuser", AppUser);
            keyValuePairs.Add("apptime", AppTime.ToString());
            keyValuePairs.Add("amount", Amount.ToString());
            keyValuePairs.Add("apptransid", AppId);
            keyValuePairs.Add("description", orderDTO.Note);
            keyValuePairs.Add("bankcode", "zalopayapp");
            keyValuePairs.Add("mac", Mac);

            // gửi request và nhận lại response
            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(keyValuePairs);
            var response = client.PostAsync(_configuration["ZaloPay:PaymentUrl"], content).Result;

            // lấy dữ liệu và gửi về
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert
                .DeserializeObject<CreateZalopayPayResponse>(responseContent);

            return responseData;
        }

        public static long GetTimeStamp(DateTime date)
        {
            return (long)(date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }
    }
}
