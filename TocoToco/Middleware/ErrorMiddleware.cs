using Microsoft.Identity.Client;
using Newtonsoft.Json;
using TocoToco.Common.Exceptions;
using TocoToco.Common.Models;
using static TocoToco.Common.Enumeration.Enum;

namespace TocoToco.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ResponseModel responseModel = new ResponseModel();
            switch (ex)
            {
                case BaseException:
                    BaseException msEx = (BaseException)ex;
                    responseModel.DevMsg = msEx.ErrorMsg;
                    responseModel.UserMsg = "Loi";
                    responseModel.Error = msEx.Result;
                    responseModel.Data = msEx.Data;
                    context.Response.StatusCode = (int)ReturnCode.BadRequest;
                    break;
                default:
                    responseModel.DevMsg = ex.Message;
                    responseModel.UserMsg = ex.Message;
                    responseModel.Error = ex.Data;
                    context.Response.StatusCode = (int)ReturnCode.ServerError;
                    break;
            }
            var jsonResponse = JsonConvert.SerializeObject(responseModel);
            context.Response.ContentType = "application/json"; // Trả về kiểu dữ liệu json
            await context.Response.WriteAsync(jsonResponse); // Trả về kết quả
        }
    }
}
