using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// 后台管理——菜单
    /// </summary>
    public class BM_Menu : AggregateRoot , IStrongOperationRecording
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
        /// 上一级菜单
        /// 0 表示为顶级菜单
        /// </summary>
        public long ParentId { get; set; } = 0;
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; } = "";
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; } = true;
        /// <summary>
        /// 跳转的url
        /// </summary>
        [Required]
        public string Url { get; set; } = "";
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = "";
        /// <summary>
        /// 是否有效: 网页是否可跳转
        /// </summary>
        public bool Enable { get; set; } = true;
        /// <summary>
        /// 排序字段（越小越前）
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
