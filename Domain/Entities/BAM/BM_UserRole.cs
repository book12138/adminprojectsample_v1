using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// 后台管理——用户与角色
    /// </summary>
    public class BM_UserRole : IStrongOperationRecording
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// BM_Role表的 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// BM_Menu表的 菜单ID
        /// </summary>
        public long MenuId { get; set; }
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
        /// <summary>
        /// true : 已删除  false ：未删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
