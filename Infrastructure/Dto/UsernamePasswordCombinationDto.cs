using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Dto
{
    /// <summary>
    /// 账户是否存在
    /// </summary>
    public class UsernamePasswordCombinationDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
