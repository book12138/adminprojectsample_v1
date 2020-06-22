using Application.Base;
using Infrastructure.Dto;
using Infrastructure.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IAccountService : IBaseService
    {
        /// <summary>
        /// 持用户名密码组合登录，获取token
        /// </summary>
        /// <param name="dto">用户名密码组合</param>
        /// <returns></returns>
        LoginResult Login(UsernamePasswordCombinationDto dto);

        /// <summary>
        /// 检查该用户名是否已经有过
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        RightOrWrongResult UserNameExists(string name);

        /// <summary>
        /// 注册新账户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        RegisterResult Register(AccountRegisterDto dto);
    }
}
