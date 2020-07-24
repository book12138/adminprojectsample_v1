using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Dto
{
    /// <summary>
    /// 新菜单记录 dto 模型
    /// </summary>
    public class NewMenuRecordDto
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// url
        /// </summary>
        [Required]        
        public string Url { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>        
        public bool IsShow { get; set; } = true;
        /// <summary>
        /// 菜单是否有效
        /// </summary>       
        public bool Enable { get; set; } = true;
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; } = "";
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = "";
        /// <summary>
        /// 父级菜单
        /// </summary>
        public int ParentId { get; set; } = 0;
    }
}
