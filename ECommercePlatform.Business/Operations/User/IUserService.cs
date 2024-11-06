using ECommercePlatform.Business.Operations.User.Dtos;
using ECommercePlatform.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto userDto);

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto userDto);

    }
}
