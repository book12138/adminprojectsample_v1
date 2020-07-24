using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    /// <summary>
    /// 强制包含 操作记录，用于约束实体，一定会有以下四个字段
    /// </summary>
    public interface IStrongOperationRecording : IEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime UpdateTime { get; set; }
        /// <summary>
        /// 创建者
        /// 0 表示system
        /// </summary>
        long Creator { get; set; }
        /// <summary>
        /// 修改者
        /// 0 表示system
        /// </summary>
        long Mender { get; set; }
    }
}
