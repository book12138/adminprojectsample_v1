using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// 后台管理——用户表
    /// </summary>
    public class BM_User : AggregateRoot , IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
