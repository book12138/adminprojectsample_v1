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
    public class BM_Menu : AggregateRoot
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
        [Required]
        public int Parent { get; set; } = 0;
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; } = "";
        /// <summary>
        /// html 标签class属性
        /// </summary>
        public string HtmlClass { get; set; } = "";
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; } = true;
        /// <summary>
        /// 跳转的url
        /// </summary>
        public string url { get; set; } = "";
        /// <summary>
        /// 排序字段（越小越前）
        /// </summary>
        public int Sort { get; set; } = 99;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 创建者
        /// 0 表示system
        /// </summary>
        public int Creator { get; set; } = 0;
        /// <summary>
        /// 修改者
        /// 0 表示system
        /// </summary>
        public int Mender { get; set; } = 0;
        /// <summary>
        /// true : 已删除  false ：未删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
