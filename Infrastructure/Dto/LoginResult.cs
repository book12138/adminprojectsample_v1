using Infrastructure.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    /// <summary>
    /// 用户登录结果
    /// </summary>
    public class LoginResult : BaseResult
    {
        /// <summary>
        /// jwt
        /// </summary>
        public string Token { get; set; }
    }
}
