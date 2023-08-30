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
        public async Task<string> Login(UserLogin userLogin)
        {
            string token = await _userService.Login(userLogin);

            return token;
        }
    }
}
