using TocoToco.Base;
using TocoToco.BL.DTOs.UserDTOs;
using TocoToco.BL.Services.UserService;
using TocoToco.DL.Entities;

namespace TocoToco.Controllers
{
    public class UserController : BaseController<UserDTO, UserCreateDTO, UserUpdateDTO>
    {
        public UserController(IUserService userService) : base(userService)
        {

        }
    }
}
