using Microsoft.AspNetCore.Mvc;
using TocoToco.Base;
using TocoToco.BL.DTOs.UserDTOs;
using TocoToco.BL.Services.UserService;
using TocoToco.Common.Models;
using TocoToco.DL.Entities;

namespace TocoToco.Controllers
{
    public class UserController : BaseController<UserDTO, UserCreateDTO, UserUpdateDTO>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// hàm đăng nhập
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Task<string></returns>
        /// created by: ntvu (30/08/2023)
        [HttpPost("login")]
        public async Task<Tokens> Login(UserLogin userLogin)
        {
            Tokens tokens = await _userService.Login(userLogin);

            return tokens;
        }

        /// <summary>
        /// hàm cấp mới access token
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="email"></param>
        /// <returns>Task<string></returns>
        /// created by: ntvu (31/08/2023)
        [HttpGet("newtoken")]
        public async Task<string> RenewAccessToken(Guid Id, string rfToken)
        {
            string token = await _userService.RenewAccessToken(Id, rfToken);

            return token;
        }
    }
}
