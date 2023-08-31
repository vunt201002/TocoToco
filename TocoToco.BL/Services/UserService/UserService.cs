using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        public async Task<Tokens> Login(UserLogin userLogin)
        {
            // check email
            var user = await _userRepository.CheckEmailExist(userLogin.Email);

            // nếu chưa được đăng ký
            if (user == null)
            {
                throw new Exception("Email chưa được đăng ký");
            }

            // check mật khẩu
            if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.PasswordHash))
            {
                throw new Exception("Sai mật khẩu");
            }

            // tạo token khi đăng nhập
            string accessToken = GenerateAccessToken(userLogin.Email);
            string refreshToken = GenerateRefreshToken();

            // lưu refresh token vào trong db
            int res = await _userRepository.UpdateRfToken(user.Id, refreshToken);

            if (res == 0)
            {
                throw new Exception("Lưu token không thành công");
            }

            return new Tokens
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// hàm tạo access token
        /// </summary>
        /// <param name="email"></param>
        /// <returns>string</returns>
        /// created by: ntvu (30/08/2023)
        private static string GenerateAccessToken(string email)
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
                    expires: DateTime.Now.AddSeconds(30),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        /// <summary>
        /// hàm tạo refresh token
        /// </summary>
        /// <returns>string</returns>
        /// created by: ntvu (31/08/2023)
        private static string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        /// <summary>
        /// hàm cấp mới access token
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="rfToken"></param>
        /// <returns>Task<string></returns>
        /// <exception cref="Exception"></exception>
        /// created by: ntvu (31/08/2023)
        public async Task<string> RenewAccessToken(Guid Id, string rfToken)
        {
            // lấy ra người dùng
            User? user = await _userRepository.Get(Id);

            // check người dùng tồn tại
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng khi tạo mới token");
            }

            // check rf token
            if (!string.Equals(user.RefreshToken, rfToken, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Refresh Token không tồn tại");
            }

            // check thời gian hết hạn
            if (user.RfExpireTime <  DateTime.Now)
            {
                throw new Exception("Token đã hết hạn, đăng nhập lại");
            }

            string accessToken = GenerateAccessToken(user.Email);

            return accessToken;
        }
    }
}
