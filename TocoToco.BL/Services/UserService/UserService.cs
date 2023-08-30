using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TocoToco.BL.Base;
using TocoToco.BL.DTOs.UserDTOs;
using TocoToco.Common.Models;
using TocoToco.DL.Constracts;
using TocoToco.DL.Entities;

namespace TocoToco.BL.Services.UserService
{
    public class UserService : BaseService<User, UserDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration
        ) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// hàm đăng ký override từ
        /// hàm add
        /// </summary>
        /// <param name="entityCreateDto"></param>
        /// <returns>Task<int></returns>
        /// created by: ntvu (30/08/2023)
        public override async Task<int> Add(UserCreateDTO userCreateDTO)
        {
            // hash mật khẩu người dùng
            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(userCreateDTO.Password);

            // gắn mật khẩu đã hash
            userCreateDTO.Password = passwordHash;

            // map từ dto sang entity
            User user = _mapper.Map<User>(userCreateDTO);

            // gửi dữ liệu xuống dl
            int res = await _userRepository.Add(user);

            if (res == 0)
            {
                throw new Exception("Thêm người dùng không thành công");
            }

            return res;
        }

        /// <summary>
        /// hàm đăng nhập
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Task<string></returns>
        /// <exception cref="Exception"></exception>
        /// created by: ntvu (30/08/2023)
        public async Task<string> Login(UserLogin userLogin)
        {
            var user = await _userRepository.CheckEmailExist(userLogin.Email);

            if (user == null)
            {
                throw new Exception("Email chưa được đăng ký");
            }

            if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.PasswordHash))
            {
                throw new Exception("Sai mật khẩu");
            }

            string token = CreateToken(userLogin.Email);

            return token;
        }

        /// <summary>
        /// hàm tạo access token
        /// </summary>
        /// <param name="email"></param>
        /// <returns>string</returns>
        /// created by: ntvu (30/08/2023)
        private static string CreateToken(string email)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                "my top secret keymy top secret keymy top secret keymy top secret key"
            ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
