using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Jwt
{
    /// <summary>
    /// jwt的 token 模型
    /// </summary>
    public class TokenModelJwt
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
    }
}
