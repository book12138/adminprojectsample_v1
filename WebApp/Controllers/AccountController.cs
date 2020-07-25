using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;
using Infrastructure.Dto;
using Infrastructure.Dto.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    /// <summary>
    /// 账号服务
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]    
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 账号应用服务
        /// </summary>
        private readonly IAccountService _accountService;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
            => this._accountService = accountService;

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public LoginResult Login([FromBody] UsernamePasswordCombinationDto dto)
            => this._accountService.Login(dto);

        /// <summary>
        /// 检测用户是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [HttpGet("UsernameExists/{username}")]
        public RightOrWrongResult UsernameExists(string username)
            => this._accountService.UserNameExists(username);

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public RegisterResult Register([FromBody] AccountRegisterDto dto)
            => this._accountService.Register(dto);
    }
}
