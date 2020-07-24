using Domain.Base;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// 后台管理——角色表
    /// </summary>
    public class BM_Role : AggregateRoot , IStrongOperationRecording
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int Sort { get; set; } = 99;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建者
        /// 0 表示system
        /// </summary>
        public long Creator { get; set; } = 0;
        /// <summary>
        /// 修改者
        /// 0 表示system
        /// </summary>
        public long Mender { get; set; } = 0;
    }
}
